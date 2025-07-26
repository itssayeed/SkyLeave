using SkyLeave.Domain.Entities;

namespace SkyLeave.Application.Services
{
    public interface ILeaveRequestService
    {
        List<LeaveRequest> GetAll();
    }
}
