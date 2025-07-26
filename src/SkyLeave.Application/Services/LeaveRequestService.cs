using System.Collections.Generic;
using SkyLeave.Application.Services;
using SkyLeave.Domain.Entities;
using SkyLeave.Domain.Interfaces;

namespace SkyLeave.Application.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public List<LeaveRequest> GetAll()
        {
            return _leaveRequestRepository.GetAll();
        }
    }
}
