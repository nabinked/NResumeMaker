using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;

namespace DbPortal
{
    public class DbTransactions<TEntity> : IDbTransactions<TEntity> where TEntity : DbEntity, new()
    {
        private readonly CommandGenerator _commandGenerator;

        public DbTransactions()
        {
            //_connectionFactory = connectionFactory;
            _commandGenerator = new CommandGenerator();
        }

        public TEntity Get(long id)
        {
            var sqlGenerator = new SqlGenerator<TEntity>();
            var sql = sqlGenerator.GetSelectByIdQuery();
            var mapper = new NMapper.Mapper<TEntity>();
            var cmd = _commandGenerator.GetNpgsqlCommand(sql, new { id });
            return mapper.GetObject(cmd) ?? new TEntity();
        }

        public IEnumerable<TEntity> GetAll(string sqlQuery, object param)
        {
            var mapper = new NMapper.Mapper<TEntity>();
            return mapper.GetObjects(_commandGenerator.GetNpgsqlCommand(sqlQuery, param));
        }

        public IEnumerable<TEntity> GetAll()
        {
            var sqlGenerator = new SqlGenerator<TEntity>();
            var sql = sqlGenerator.GetSelectAllQuery();
            var mapper = new NMapper.Mapper<TEntity>();
            return mapper.GetObjects(_commandGenerator.GetNpgsqlCommand(sql));
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return null;
        }

        public IEnumerable<TEntity> GetList()
        {
            return new List<TEntity>();
        }

        public TEntity Find(Expression<Func<TEntity, object>> property, object value)
        {
            var sqlGen = new SqlGenerator<TEntity>();
            var colunmName = GetCorrectPropertyName(property);
            var sql = sqlGen.GetSelectByColumnNameQuery(colunmName);
            var mapper = new NMapper.Mapper<TEntity>();
            dynamic obj = new ExpandoObject();
            var paramObj = (IDictionary<string, object>)obj;
            paramObj[colunmName] = value;
            var cmd = _commandGenerator.GetNpgsqlCommand(sql, obj);
            return mapper.GetObject(cmd);
        }

        private string GetCorrectPropertyName<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body != null)
            {
                return body.Member.Name;
            }
            var op = ((UnaryExpression)expression.Body).Operand;
            var memberExpression = op as MemberExpression;
            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }
            throw new Exception("Property parsing unsuccessful in" + this.GetType());
        }

        public long Create(TEntity tEntity)
        {
            var sqlGen = new SqlGenerator<TEntity>();
            var sql = sqlGen.GetInsertQuery();
            var cmd = _commandGenerator.GetNpgsqlCommand(sql, tEntity);
            return NMapper.Mapper.GetObject<long>(cmd);

        }


        public List<TEntity> GetAllByProperty(Expression<Func<TEntity, object>> propertyExpresion, object value)
        {
            var colunmName = GetCorrectPropertyName(propertyExpresion);
            var sqlGen = new SqlGenerator<TEntity>();
            var sql = sqlGen.GetSelectByColumnNameQuery(colunmName);
            dynamic obj = new ExpandoObject();
            var paramObj = (IDictionary<string, object>)obj;
            paramObj[colunmName] = value;
            var cmd = _commandGenerator.GetNpgsqlCommand(sql, obj);
            return new NMapper.Mapper<TEntity>().GetObjects(cmd);
        }
        public bool Update(TEntity tEntity)
        {
            var sqlGen = new SqlGenerator<TEntity>();
            var sql = sqlGen.GetUpdateQuery();
            var cmd = _commandGenerator.GetNpgsqlCommand(sql, tEntity);
            cmd.Connection.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(long id)
        {
            var sqlGen = new SqlGenerator<TEntity>();
            var sql = sqlGen.GetDeleteQuery();
            var cmd = _commandGenerator.GetNpgsqlCommand(sql, new { id });
            cmd.Connection.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}