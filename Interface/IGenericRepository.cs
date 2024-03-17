using DevAlApplication.Models.GeneralModels;
using System.Linq.Expressions;

namespace DevAlApplication.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        AppDbContext GetDbContext();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(Guid ID);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
