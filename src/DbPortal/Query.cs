using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using Npgsql;

namespace DbPortal
{
    public class CommandGenerator
    {
        List<string> SqlParams { get; set; }
        Dictionary<string, object> Params { get; set; }
        public IDbConnection Connection
        {
            get
            {
                return DbConnection.GetConnection();
            }
        }

        #region Public Methods

        public IDbCommand GetNpgsqlCommand(string sql, object parameters = null)
        {
            var cmd = GetNpgsqlCommandOnly(sql, parameters);
            cmd.Connection = Connection;
            return cmd;
        }

        public IDbCommand GetNpgsqlCommandOnly(string sql, object parameters = null)
        {
            if (parameters == null)
            {
                return new NpgsqlCommand(sql);
            }
            else
            {
                SetParams(sql, parameters);

                var cmd = new NpgsqlCommand(sql);

                if (!Params.Any()) return cmd;

                foreach (var keyValuePair in Params)
                {
                    cmd.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                }

                return cmd;
            }

        }
        #endregion

        #region Private Methods

        void SetParams(string sql, object parameters)
        {
            Params = new Dictionary<string, object>();
            SqlParams = GeSqlParams(sql).ToList();
            foreach (var param in SqlParams)
            {
                Params.Add(param, GetPropertyValue(parameters, CleanParameter(param)) ?? DBNull.Value);
            }
        }

        IEnumerable<string> GeSqlParams(string sql)
        {
            var sqlParams = new List<string>();
            var paramStartIndex = 0;
            var paramFound = false;
            for (var i = 0; i < sql.Length; i++)
            {
                var c = sql[i];

                switch (c)
                {
                    case '?':
                    case '@':
                        paramFound = true;
                        paramStartIndex = i;
                        break;
                }
                var endOfSql = i == sql.Length - 1;
                if ((char.IsWhiteSpace(c) || endOfSql) && paramFound)
                {
                    paramFound = false;
                    var paramStopIndex = endOfSql ? i + 1 : i;
                    var param = RemoveAll(sql.Substring(paramStartIndex, paramStopIndex - paramStartIndex), (new[] { ";", ")", "," }));
                    if (!sqlParams.Contains(param))
                    {
                        sqlParams.Add(param);
                    }
                }
            }
            return sqlParams;
        }

        static string RemoveAll(string str, string[] stringToReplace)
        {
            var sb = new StringBuilder(str);

            foreach (var s in stringToReplace)
            {
                if (string.IsNullOrEmpty(s)) continue;
                sb.Replace(s, "");
            }

            return sb.ToString();
        }

        static object GetPropertyValue(object obj, string propertyName)
        {
            if (obj is IDynamicMetaObjectProvider)
            {
                IDictionary<string, object> propertyValues = (IDictionary<string, object>)obj;
                return propertyValues[propertyName];
            }
            else
            {
                if (obj == null || string.IsNullOrWhiteSpace(propertyName)) return null;
                var properties = obj.GetType().GetProperties();
                object first = null;
                var propertyFound = false;
                foreach (PropertyInfo propertyInfo in properties)
                {
                    if (String.Equals(propertyInfo.Name, propertyName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        first = propertyInfo.GetValue(obj, null);
                        propertyFound = true;
                        break;
                    }
                }
                if (!propertyFound)
                {
                    throw new Exception($"Property {propertyName} not found");
                }
                return properties.Any() ? first : null;
            }

        }

        static string CleanParameter(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                switch (name[0])
                {
                    case '@':
                    case '?':
                        return name.Substring(1).Trim();
                }
            }
            return name;

        }

        #endregion
    }
}
