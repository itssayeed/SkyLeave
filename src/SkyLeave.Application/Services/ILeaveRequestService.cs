using SkyLeave.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyLeave.Application.Services
{
    public interface ILeaveRequestService
    {
        Task<List<LeaveRequest>> GetAllAsync();
        Task<LeaveRequest> GetByIdAsync(int id);
        Task<LeaveRequest> CreateAsync(LeaveRequest request);
        Task UpdateAsync(LeaveRequest request);
        Task DeleteAsync(int id);
    }
}