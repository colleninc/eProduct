using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eProduct.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity);
        Task UpdateAsync(Guid id, T entity);
        Task DeleteAsync(Guid id);
    }
}
