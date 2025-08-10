// File: SkyLeave.Infrastructure/Repositories/LeaveBalanceRepository.cs
using Microsoft.EntityFrameworkCore;
using SkyLeave.Domain.Entities;
using SkyLeave.Domain.Interfaces;
using SkyLeave.Infrastructure.Persistence;

namespace SkyLeave.Infrastructure.Repositories
{
    public class LeaveBalanceRepository : Repository<LeaveBalance>, ILeaveBalanceRepository
    {
        public LeaveBalanceRepository(SkyLeaveDbContext context) : base(context) { }

        public async Task<LeaveBalance> GetByUserIdAndLeaveTypeAsync(int userId, string leaveType)
        {
            return await _dbSet.AsNoTracking()
                .FirstOrDefaultAsync(lb => lb.UserId == userId && lb.LeaveType == leaveType);
        }
    }
}