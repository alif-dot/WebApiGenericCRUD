using System.Linq.Expressions;
using WebApiGenericCRUD.Models;

namespace WebApiGenericCRUD.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByIdAsync(Int64 id);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        Task Delete(Int64 id);
        Task<bool> SaveChangesAsync();
    }
}
