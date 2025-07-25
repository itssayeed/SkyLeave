using SkyLeave.Domain.Entities;
using SkyLeave.Domain.Interfaces;

namespace SkyLeave.Infrastructure.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly List<LeaveRequest> _leaveRequests = new();

        public Task<IEnumerable<LeaveRequest>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<LeaveRequest>>(_leaveRequests);
        }

        public Task<LeaveRequest?> GetByIdAsync(int id)
        {
            var request = _leaveRequests.FirstOrDefault(lr => lr.Id == id);
            return Task.FromResult(request);
        }

        public Task AddAsync(LeaveRequest leaveRequest)
        {
            leaveRequest.Id = _leaveRequests.Count + 1;
            _leaveRequests.Add(leaveRequest);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(LeaveRequest leaveRequest)
        {
            var index = _leaveRequests.FindIndex(lr => lr.Id == leaveRequest.Id);
            if (index != -1)
                _leaveRequests[index] = leaveRequest;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var item = _leaveRequests.FirstOrDefault(lr => lr.Id == id);
            if (item != null)
                _leaveRequests.Remove(item);
            return Task.CompletedTask;
        }
    }
}
