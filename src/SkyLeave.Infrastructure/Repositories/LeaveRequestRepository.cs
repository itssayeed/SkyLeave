using SkyLeave.Domain.Entities;
using SkyLeave.Domain.Interfaces;

namespace SkyLeave.Infrastructure.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        public List<LeaveRequest> GetAll()
        {
            return new List<LeaveRequest>
            {
                new LeaveRequest
                {
                    Id = 1,
                    EmployeeId = "EMP001",
                    EmployeeName = "Sayeed Ahmed",
                    Days = 3,
                    StartDate = new DateTime(2025, 7, 20),
                    EndDate = new DateTime(2025, 7, 22),
                    LeaveType = "Annual",
                    Status = "Approved"
                },
                new LeaveRequest
                {
                    Id = 2,
                    EmployeeId = "EMP002",
                    EmployeeName = "Ravi Kumar",
                    Days = 2,
                    StartDate = new DateTime(2025, 7, 25),
                    EndDate = new DateTime(2025, 7, 26),
                    LeaveType = "Sick",
                    Status = "Pending"
                }
            };
        }
    }
}
