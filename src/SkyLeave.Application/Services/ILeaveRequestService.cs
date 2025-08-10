using SkyLeave.Domain.Entities;

namespace SkyLeave.Application.Services
{
    public interface ILeaveRequestService
    {
        Task<List<LeaveRequest>> GetAllAsync(int page = 1, int pageSize = 10);
        Task<LeaveRequest> GetByIdAsync(int id);
        Task<LeaveRequest> CreateAsync(LeaveRequest request);
        Task UpdateAsync(LeaveRequest request);
        Task DeleteAsync(int id);
        Task ApproveLeaveRequestAsync(int id, string status, string approvedBy);
    }
}