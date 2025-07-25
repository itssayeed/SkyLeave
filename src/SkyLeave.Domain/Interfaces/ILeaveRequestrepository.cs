using SkyLeave.Domain.Entities;

namespace SkyLeave.Domain.Interfaces
{
    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<LeaveRequest>> GetAllAsync();
        Task<LeaveRequest?> GetByIdAsync(int id);
        Task AddAsync(LeaveRequest leaveRequest);
        Task UpdateAsync(LeaveRequest leaveRequest);
        Task DeleteAsync(int id);
    }
}
