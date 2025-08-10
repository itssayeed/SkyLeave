// File: SkyLeave.Domain/Interfaces/ILeaveBalanceRepository.cs
using SkyLeave.Domain.Entities;

namespace SkyLeave.Domain.Interfaces
{
    public interface ILeaveBalanceRepository : IRepository<LeaveBalance>
    {
        Task<LeaveBalance> GetByUserIdAndLeaveTypeAsync(int userId, string leaveType);
    }
}