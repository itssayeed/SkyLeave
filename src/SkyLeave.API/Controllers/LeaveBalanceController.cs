// File: SkyLeave.API/Controllers/LeaveBalanceController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyLeave.Domain.Entities;
using SkyLeave.Domain.Interfaces;

namespace SkyLeave.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveBalanceController : ControllerBase
    {
        private readonly ILeaveBalanceRepository _repository;
        private readonly ILogger<LeaveBalanceController> _logger;

        public LeaveBalanceController(ILeaveBalanceRepository repository, ILogger<LeaveBalanceController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize(Policy = "Employee")]
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<LeaveBalance>>> GetByUserId(int userId)
        {
            var balances = await _repository.GetAllAsync();
            var userBalances = balances.Where(b => b.UserId == userId).ToList();
            _logger.LogInformation("Retrieved {Count} leave balances for user {UserId}.", userBalances.Count, userId);
            return Ok(userBalances);
        }
    }
}