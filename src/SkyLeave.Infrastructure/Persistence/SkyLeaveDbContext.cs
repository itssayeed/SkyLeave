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
        public DbSet<LeaveBalance> LeaveBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LeaveRequest>().HasData(
                new LeaveRequest
                {
                    Id = 1111,
                    EmployeeName = "Alice Johnson",
                    StartDate = new DateTime(2025, 8, 1),
                    EndDate = new DateTime(2025, 8, 4),
                    LeaveType = "Vacation",
                    Status = "Pending"
                },
                new LeaveRequest
                {
                    Id = 2111,
                    EmployeeName = "Bob Smith",
                    StartDate = new DateTime(2025, 8, 2),
                    EndDate = new DateTime(2025, 8, 5),
                    LeaveType = "Medical Leave",
                    Status = "Approved"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", PasswordHash = "$2b$12$tpAcK1BIFHMwdWYYAIAESu3IBjCRA4hhHxAVQSCmf/j2teGletTqK", Role = "Admin" },
                new User { Id = 2, Username = "emp", PasswordHash = "$2b$12$FQD75CKzriTgSr/6RI8e1uuP1oE0t.GO.WUrv11E.K3waf38iBwlW", Role = "Employee" }
            );

            modelBuilder.Entity<LeaveBalance>().HasData(
                new LeaveBalance { Id = 1, UserId = 1, LeaveType = "Vacation", AvailableDays = 20 },
                new LeaveBalance { Id = 2, UserId = 1, LeaveType = "Medical Leave", AvailableDays = 10 },
                new LeaveBalance { Id = 3, UserId = 2, LeaveType = "Vacation", AvailableDays = 15 },
                new LeaveBalance { Id = 4, UserId = 2, LeaveType = "Medical Leave", AvailableDays = 5 }
            );

            modelBuilder.Entity<LeaveBalance>()
                .HasOne(lb => lb.User)
                .WithMany(u => u.LeaveBalances)
                .HasForeignKey(lb => lb.UserId);
        }
    }
}