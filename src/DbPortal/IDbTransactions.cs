using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DbPortal
{
    public interface IDbTransactions<TEntity>
    {
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll(string sqlQuery, object param);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        long Create(TEntity tEntity);
        bool Update(TEntity tEntity);
    }
}