using System.Collections.Generic;
using SkyLeave.Domain.Entities;

namespace SkyLeave.Domain.Interfaces
{
    public interface ILeaveRequestRepository
    {
        List<LeaveRequest> GetAll();
    }
}
