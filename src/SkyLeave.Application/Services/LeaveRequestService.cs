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

        public async Task<List<LeaveRequest>> GetAllAsync()
        {
            return await _leaveRequestRepository.GetAllAsync() ?? new List<LeaveRequest>();
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
            await _leaveRequestRepository.SaveChangesAsync();  // Ensure save after delete
        }
    }
}