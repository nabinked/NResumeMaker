using System;
using System.Collections.Generic;
using System.Linq;

namespace DbPortal
{
    public class SqlGenerator<TEntity> where TEntity : DbEntity, new()
    {
        private readonly string _schemaName;
        private readonly string _entityName;

        private List<string> ColumnNames { get; set; }
        public SqlGenerator()
        {
            var t = new TEntity();
            _schemaName = t.SchemaName;
            _entityName = t.EntityName;
        }

        #region Public Members
        public string GetSelectAllQuery()
        {
            return $"SELECT * FROM {_schemaName}.{_entityName};";
        }

        public string GetSelectAllByIdQuery()
        {
            return $"SELECT * FROM {_schemaName}.{_entityName} WHERE id = @id;";
        }

        public string GetSelectByIdQuery()
        {
            return $"SELECT * FROM {_schemaName}.{_entityName} WHERE id = @Id;";
        }

        public string GetSelectByColumnNameQuery(string columnName)
        {
            var dbColumnName = NMapper.NamingConvention.ProcessObjectNamesToDbNames(columnName);
            return $"SELECT * FROM {_schemaName}.{_entityName} WHERE {dbColumnName} = @{columnName};";
        }

        public string GetInsertQuery()
        {
            var insertableColumnNamesList = GetColumnNameList(typeof(TEntity));
            var insertableColumnNames = string.Join(", ", insertableColumnNamesList);
            var parameterNames = string.Join(", ", insertableColumnNamesList.Select(insertColumName => $"@{insertColumName.Replace("_", "")}").ToList());
            var sql =
                $"INSERT INTO {_schemaName}.{_entityName} ({insertableColumnNames}) VALUES ({parameterNames}) RETURNING id;";
            return sql;
        }

        public string GetDeleteQuery()
        {
            return $"DELETE FROM {_schemaName}.{_entityName} WHERE id = @id;";
        }

        public string GetSelectLimitedQuery(int offSet, int limit)
        {
            return $"SELECT * FROM {_schemaName}.{_entityName} ORDER BY id LIMIT {limit} OFFSET {offSet};";
        }

        public string GetUpdateQuery()
        {
            var updatableColumnNamesList = GetColumnNameList(typeof(TEntity));
            var setString = GetSetStringForUpdateQuery(updatableColumnNamesList);
            var sql = $"UPDATE {_schemaName}.{_entityName} SET {setString} WHERE id = @id;";
            return sql;

            ;
        }
        #endregion

        #region Private Members
        private string GetSetStringForUpdateQuery(List<string> updatableColumnNames)
        {
            var setString = "";
            for (int i = 0; i < updatableColumnNames.Count; i++)
            {
                var columnName = updatableColumnNames[i];
                setString += columnName + " = @" + columnName.Replace("_", "");
                if (i != updatableColumnNames.Count - 1)
                {
                    setString += " ,";
                }
            }
            return setString;
        }
        private List<string> GetColumnNameList(Type type)
        {
            ColumnNames = type.GetProperties().Where(x => !x.GetMethod.IsVirtual || x.GetMethod.IsFinal).Select(x => x.Name).ToList();
            var unProcessedColumnNames = ColumnNames.Where(x => !x.Equals("id", StringComparison.InvariantCultureIgnoreCase)).ToList();
            return unProcessedColumnNames.Select(NMapper.NamingConvention.ProcessObjectNamesToDbNames).ToList();
        }
        #endregion


    }
}
