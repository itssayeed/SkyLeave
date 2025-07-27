using SkyLeave.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyLeave.Domain.Interfaces
{
    public interface ILeaveRequestRepository : IRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetByEmployeeAsync(string employeeName);
        Task<List<LeaveRequest>> GetByStatusAsync(string status);
        Task ApproveLeaveRequestAsync(int id, string status);
        Task SaveChangesAsync();  // New method to save changes in the repository
    }
}