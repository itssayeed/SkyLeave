using Microsoft.EntityFrameworkCore;
using SkyLeave.Domain.Entities;
using SkyLeave.Domain.Interfaces;
using SkyLeave.Infrastructure.Persistence;

namespace SkyLeave.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SkyLeaveDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(SkyLeaveDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
    public class LeaveRequestRepository : Repository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(SkyLeaveDbContext context) : base(context) { }

        public async Task<List<LeaveRequest>> GetByEmployeeAsync(string employeeName)
        {
            return await _dbSet.AsNoTracking().Where(lr => lr.EmployeeName == employeeName).ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetByPageAsync(int page = 1, int pageSize = 10)
        {
            return await _dbSet.AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetByStatusAsync(string status)
        {
            return await _dbSet.AsNoTracking().Where(lr => lr.Status == status).ToListAsync();
        }

        public async Task ApproveLeaveRequestAsync(int id, string status)
        {
            var leaveRequest = await _dbSet.FindAsync(id);
            if (leaveRequest != null)
            {
                leaveRequest.Status = status;
                await SaveChangesAsync();
            }
        }
    }
}