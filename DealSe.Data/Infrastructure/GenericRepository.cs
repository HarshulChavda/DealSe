using DealSe.Domain;
using DealSe.Domain.Interface;
using DealSe.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DealSe.Data.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity : class
    {
        private readonly DealSeContext _dbContext;
        private readonly DbSet<TEntity> dbset_crud;
        public GenericRepository(DealSeContext dbContext)
        {
            _dbContext = dbContext;
            dbset_crud = _dbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression).AsNoTracking();
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbContext.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
        }
        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual void RemoveRange(Expression<Func<TEntity, bool>> predicate)
        {
            var items = GetMany(predicate);
            dbset_crud.RemoveRange(items);
            _dbContext.SaveChanges();
        }
        public virtual void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams)
        {
            _dbContext.Database.ExecuteSqlRawAsync(procedureCommand, sqlParams);
        }
        public IEnumerable<TEntity> SQLQuery(string sql, params SqlParameter[] parameters)
        {
            return _dbContext.Set<TEntity>().FromSqlRaw(sql, parameters);
        }
    }
}
