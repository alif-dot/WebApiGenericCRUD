using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiGenericCRUD.Models;

namespace WebApiGenericCRUD.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Int64 id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> perdicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(perdicate);
        }

        public void Add(T entity)
        {
            entity.AddedDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            _entities.Update(entity);
        }

        public async Task Delete(Int64 id)
        {
            var entity = await _entities.FindAsync(id);
            _entities.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}
