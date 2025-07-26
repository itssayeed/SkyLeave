using Microsoft.EntityFrameworkCore;
using SkyLeave.Infrastructure.Persistence;

namespace SkyLeave.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SkyLeaveDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SkyLeaveDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync(); 
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task SaveASync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

