using Microsoft.EntityFrameworkCore;
using SkyLeave.Domain.Entities;

namespace SkyLeave.Infrastructure.Persistence
{
    public class SkyLeaveDbContext : DbContext
    {
        public SkyLeaveDbContext(DbContextOptions<SkyLeaveDbContext> options)
            : base(options) { }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LeaveRequest>().HasData(
                new LeaveRequest
                {
                    Id = 1111,
                    EmployeeName = "Alice Johnson",
                    StartDate = new DateTime(2025, 8, 1), // Static hardcoded value
                    EndDate = new DateTime(2025, 8, 4), // Static hardcoded value
                    LeaveType = "Vacation",
                    Status = "Pending"
                },
                new LeaveRequest
                {
                    Id = 2111,
                    EmployeeName = "Bob Smith",
                    StartDate = new DateTime(2025, 8, 2), // Static hardcoded value
                    EndDate = new DateTime(2025, 8, 5), // Static hardcoded value
                    LeaveType = "Medical Leave",
                    Status = "Approved"
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", PasswordHash = "$2b$12$tpAcK1BIFHMwdWYYAIAESu3IBjCRA4hhHxAVQSCmf/j2teGletTqK", Role = "Admin" }, // Static hash for "admin123"
                new User { Id = 2, Username = "emp", PasswordHash = "$2b$12$FQD75CKzriTgSr/6RI8e1uuP1oE0t.GO.WUrv11E.K3waf38iBwlW", Role = "Employee" } // Static hash for "emp123"
            );
        }
    }
}