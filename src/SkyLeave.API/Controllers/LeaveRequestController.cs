using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyLeave.Application.Services;
using SkyLeave.Domain.Entities;

namespace SkyLeave.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _service;
        private readonly ILogger<LeaveRequestController> _logger;

        public LeaveRequestController(ILeaveRequestService service, ILogger<LeaveRequestController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize(Policy = "Employee")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetAll()
        {
            try
            {
                var allLeaves = await _service.GetAllAsync();
                _logger.LogInformation("Retrieved {Count} leave requests.", allLeaves?.Count ?? 0);
                return Ok(allLeaves);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving leave requests.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "Employee")]
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequest>> GetById(int id)
        {
            try
            {
                var leave = await _service.GetByIdAsync(id);
                if (leave == null)
                    return NotFound();
                return leave;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving leave request with ID {Id}.", id);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<ActionResult<LeaveRequest>> Create([FromBody] LeaveRequest request)
        {
            if (!ModelState.IsValid || request.EndDate < request.StartDate)
                return BadRequest("Invalid date range or data.");

            try
            {
                var created = await _service.CreateAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating leave request.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] LeaveRequest leaveRequest)
        {
            if (!ModelState.IsValid || id != leaveRequest.Id || leaveRequest.EndDate < leaveRequest.StartDate)
                return BadRequest("Invalid data or ID mismatch");

            try
            {
                var existingLeave = await _service.GetByIdAsync(id);
                if (existingLeave == null)
                    return NotFound();

                // Map incoming values to the existing tracked entity
                existingLeave.EmployeeName = leaveRequest.EmployeeName;
                existingLeave.StartDate = leaveRequest.StartDate;
                existingLeave.EndDate = leaveRequest.EndDate;
                existingLeave.LeaveType = leaveRequest.LeaveType;
                existingLeave.Status = leaveRequest.Status;

                await _service.UpdateAsync(existingLeave); // Update the existing entity
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating leave request with ID {Id}.", id);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var leave = await _service.GetByIdAsync(id);
                if (leave == null)
                    return NotFound();

                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting leave request with ID {Id}.", id);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}