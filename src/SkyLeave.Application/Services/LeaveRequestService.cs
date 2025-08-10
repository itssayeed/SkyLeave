using SkyLeave.Domain.Entities;
using SkyLeave.Domain.Interfaces;

namespace SkyLeave.Application.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;

        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository, ILeaveBalanceRepository leaveBalanceRepository)
        {
            _leaveRequestRepository = leaveRequestRepository ?? throw new ArgumentNullException(nameof(leaveRequestRepository));
            _leaveBalanceRepository = leaveBalanceRepository ?? throw new ArgumentNullException(nameof(leaveBalanceRepository));
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
            var daysRequested = (request.EndDate - request.StartDate).Days + 1;
            var balance = await _leaveBalanceRepository.GetByUserIdAndLeaveTypeAsync(2, request.LeaveType); // Assuming UserId=2 for "emp"
            if (balance == null || balance.AvailableDays < daysRequested)
                throw new InvalidOperationException("Insufficient leave balance.");

            _leaveRequestRepository.Add(request);
            balance.AvailableDays -= daysRequested;
            _leaveBalanceRepository.Update(balance);
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