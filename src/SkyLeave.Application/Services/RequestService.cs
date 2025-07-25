using SkyLeave.Domain.Entities;
using SkyLeave.Domain.Interfaces;

namespace SkyLeave.Application.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _repository;

        public LeaveRequestService(ILeaveRequestRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<LeaveRequest>> GetAllAsync() => _repository.GetAllAsync();

        public Task<LeaveRequest?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(LeaveRequest leaveRequest) => _repository.AddAsync(leaveRequest);

        public Task UpdateAsync(LeaveRequest leaveRequest) => _repository.UpdateAsync(leaveRequest);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
