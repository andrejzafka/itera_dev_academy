/// 
/// This is example of a generic repository for retrieving data from Entity Framework DBContext.
/// 
/// For more information about generic classes go to https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/.
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericsExample
{
    public abstract class GenericRepository<CDbContext, TEntity> : IGenericRepository<TEntity> 
        where TEntity : class where CDbContext : DbContext, new()
    {
        private CDbContext _dbContext = new CDbContext();

        public CDbContext Context
        {
            get => _dbContext;
            set => _dbContext = value;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsNoTracking();
            return query;
        }

        public virtual IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbContext.Set<TEntity>().AsNoTracking();

            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsNoTracking().Where(predicate);
            return query;
        }

        public virtual TEntity FindById(int id)
        {
            TEntity entity = _dbContext.Set<TEntity>().Find(id);
            return entity;
        }

        public virtual Task<TEntity> FindByIdAsync(int id)
        {
            var entity = _dbContext.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public virtual void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual bool Save()
        {
            var result = _dbContext.SaveChanges();
            return result > 0;
        }

        public virtual async Task<bool> SaveAsync()
        {
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
