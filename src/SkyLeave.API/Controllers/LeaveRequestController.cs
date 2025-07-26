using Microsoft.AspNetCore.Mvc;
using SkyLeave.Application.Services;

namespace SkyLeave.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _leaveRequestService.GetAll();
            return Ok(data);
        }
    }
}
