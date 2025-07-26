using Microsoft.EntityFrameworkCore;
using SkyLeave.Domain.Entities;

namespace SkyLeave.Infrastructure.Persistence
{
    public class SkyLeaveDbContext : DbContext
    {
        public SkyLeaveDbContext(DbContextOptions<SkyLeaveDbContext> options)
            : base(options) { }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
