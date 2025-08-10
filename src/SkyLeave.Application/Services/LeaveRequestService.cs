using SkyLeave.Domain.Entities;
using SkyLeave.Domain.Interfaces;

namespace SkyLeave.Application.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository ?? throw new ArgumentNullException(nameof(leaveRequestRepository));
        }

        public async Task<List<LeaveRequest>> GetAllAsync(int page = 1, int pageSize = 10)
        {
            return await _leaveRequestRepository.GetByPageAsync(page, pageSize) ?? new List<LeaveRequest>();
        }

        public async Task<LeaveRequest> GetByIdAsync(int id)
        {
            return await _leaveRequestRepository.GetByIdAsync(id);
        }

        public async Task<LeaveRequest> CreateAsync(LeaveRequest request)
        {
            _leaveRequestRepository.Add(request);
            await _leaveRequestRepository.SaveChangesAsync();
            return request;
        }

        public async Task UpdateAsync(LeaveRequest request)
        {
            _leaveRequestRepository.Update(request);
            await _leaveRequestRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _leaveRequestRepository.DeleteAsync(id);
            await _leaveRequestRepository.SaveChangesAsync();
        }
        public async Task ApproveLeaveRequestAsync(int id, string status, string approvedBy)
        {
            if (!new[] { "Approved", "Rejected" }.Contains(status))
                throw new ArgumentException("Status must be 'Approved' or 'Rejected'.");
            await _leaveRequestRepository.ApproveLeaveRequestAsync(id, status, approvedBy);
        }
    }
}