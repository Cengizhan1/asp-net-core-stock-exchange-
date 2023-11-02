using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstraction
{
    public interface IRepository<T> where T : class, IBaseEntity, new()
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByGuid(Guid guid);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<int> Count(Expression<Func<T, bool>> predicate = null);
    }
}
