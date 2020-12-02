using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DealSe.Data.Infrastructure
{
    public interface IGenericRepository<TEntity>
       where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        void RemoveRange(Expression<Func<TEntity, bool>> predicate);
        void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams);
        IEnumerable<TEntity> SQLQuery(string sql, params SqlParameter[] parameters);
    }
}
