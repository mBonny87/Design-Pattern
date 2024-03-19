using Microsoft.EntityFrameworkCore;

namespace OnlineStore.MultiTenant.Api.DesignPatterns.Repository
{
    public class Repository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext
    {
        private readonly TContext _context;
        private DbSet<T> entities;

        public Repository(TContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(int id)
        {
            return entities.Find(id);
        }

        public void Add(T entity)
        {
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
