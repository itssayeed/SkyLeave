using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyLeave.Domain.Entities;
using SkyLeave.Infrastructure.Repositories;

namespace SkyLeave.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IRepository<LeaveRequest> _repository;

        public LeaveRequestController(IRepository<LeaveRequest> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [Authorize(Policy = "Employee")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetAll()
        {
            var allLeaves = await _repository.GetAllAsync();
            return Ok(allLeaves);
        }

        [Authorize(Policy = "Employee")]
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequest>> GetById(int id)
        {
            var leave = await _repository.GetByIdAsync(id);
            if (leave == null)
                return NotFound();
            return leave;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<ActionResult<LeaveRequest>> Create(LeaveRequest request)
        {
            var created = await _repository.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeaveRequest(int id, LeaveRequest leaveRequest)
        {
            if (leaveRequest == null)
                return BadRequest("request body is null");

            if (id != leaveRequest.Id)
                return BadRequest("ID mismatch");

            var existingLeave = await _repository.GetByIdAsync(id);
            if (existingLeave == null)
                return NotFound();

            existingLeave.EmployeeId = leaveRequest.EmployeeId;
            existingLeave.EmployeeName = leaveRequest.EmployeeName;
            existingLeave.Days = leaveRequest.Days;
            existingLeave.StartDate = leaveRequest.StartDate;
            existingLeave.EndDate = leaveRequest.EndDate;
            existingLeave.LeaveType = leaveRequest.LeaveType;
            existingLeave.Status = leaveRequest.Status;

            await _repository.UpdateAsync(existingLeave);

            return NoContent();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            var leave = await _repository.GetByIdAsync(id);
            if (leave == null)
                return NotFound();

            await _repository.DeleteAsync(leave);
            return NoContent();
        }

    }
}
