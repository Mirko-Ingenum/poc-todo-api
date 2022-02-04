using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Query;

namespace Core.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(string id);

        Task<T> CreateAsync(T obj);

        Task<T> UpdateAsync(T obj);

        Task<bool> DeleteAsync(string id);

        Task<IEnumerable<T>> GetMuliple(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);

        Task<T> GetFirstOrDefault(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);

        Task<string> GetIdAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);

        Task<bool> Exists(Expression<Func<T, bool>> predicate);

        Task<int> Count(Expression<Func<T, bool>> predicate = null);
    }
}


