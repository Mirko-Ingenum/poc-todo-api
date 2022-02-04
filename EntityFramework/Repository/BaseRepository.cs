using System;
namespace EntityFramework.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Core.Repository;
    using Model.Database;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;

    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly TodoContext context;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(TodoContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity obj)
        {
            if (await this.dbSet.AnyAsync(x => x.Id == obj.Id))
            {
                return null;
            }

            var result = await this.dbSet.AddAsync(obj);

            var changes = await this.context.SaveChangesAsync();

            return changes > 0 ? result.Entity : null;
        }

        public virtual async Task<bool> DeleteAsync(string id)
        {
            var objToDelete = await this.dbSet.FindAsync(id);

            if (objToDelete != null)
            {
                this.dbSet.Remove(objToDelete);

                await this.context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            if (obj == null)
            {
                return null;
            }

            this.context.Update(obj);

            var changes = await this.context.SaveChangesAsync();

            return changes > 0 ? obj : null;
        }

        public virtual async Task<IEnumerable<TEntity>> GetMuliple(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = this.dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.dbSet.AnyAsync(predicate);
        }

        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await this.dbSet.CountAsync();
            }

            return await this.dbSet.CountAsync(predicate);

        }

        public virtual async Task<TEntity> GetFirstOrDefault(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = this.dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<string> GetIdAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = this.dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
        }
    }
}

