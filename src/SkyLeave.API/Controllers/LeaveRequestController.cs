using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyLeave.Application.DTOs;
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
        private readonly IMapper _mapper;

        public LeaveRequestController(ILeaveRequestService service, ILogger<LeaveRequestController> logger, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize(Policy = "Employee")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var allLeaves = await _service.GetAllAsync(page, pageSize);
            _logger.LogInformation("Retrieved {Count} leave requests.", allLeaves?.Count ?? 0);
            return Ok(_mapper.Map<IEnumerable<LeaveRequestDto>>(allLeaves));
        }

        [Authorize(Policy = "Employee")]
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> GetById(int id)
        {
            var leave = await _service.GetByIdAsync(id);
            if (leave == null)
                return NotFound();
            return Ok(_mapper.Map<LeaveRequestDto>(leave));
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<ActionResult<LeaveRequestDto>> Create([FromBody] CreateLeaveRequestDto requestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = _mapper.Map<LeaveRequest>(requestDto);
            var created = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<LeaveRequestDto>(created));
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] LeaveRequestDto requestDto)
        {
            if (!ModelState.IsValid || id != requestDto.Id)
                return BadRequest(ModelState);

            var existingLeave = await _service.GetByIdAsync(id);
            if (existingLeave == null)
                return NotFound();

            _mapper.Map(requestDto, existingLeave);
            await _service.UpdateAsync(existingLeave);
            return NoContent();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var leave = await _service.GetByIdAsync(id);
            if (leave == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveLeaveRequest(int id, [FromBody] ApproveLeaveRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.ApproveLeaveRequestAsync(id, request.Status, User.Identity?.Name ?? "Unknown");
            _logger.LogInformation("Leave request {Id} set to {Status} by {ApprovedBy}.", id, request.Status, User.Identity?.Name);
            return NoContent();
        }
    }
}