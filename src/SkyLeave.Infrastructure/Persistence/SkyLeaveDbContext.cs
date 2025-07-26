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
            modelBuilder.Entity<LeaveRequest>().HasData(
        new LeaveRequest
        {
            Id = 1111,
            EmployeeName = "Alice Johnson",
            StartDate = DateTime.Today.AddDays(2),
            EndDate = DateTime.Today.AddDays(5),
            LeaveType = "Vacation",
            Status = "Pending"
        },
        new LeaveRequest
        {
            Id = 2111,
            EmployeeName = "Bob Smith",
            StartDate = DateTime.Today.AddDays(3),
            EndDate = DateTime.Today.AddDays(6),
            LeaveType = "Medical Leave",
            Status = "Approved"
        }
    );
        }
    }
}
