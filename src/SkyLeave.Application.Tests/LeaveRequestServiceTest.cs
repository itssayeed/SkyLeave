using Microsoft.EntityFrameworkCore;
using Moq;
using SkyLeave.Application.Services;
using SkyLeave.Domain.Entities;
using SkyLeave.Domain.Interfaces;
using SkyLeave.Infrastructure.Persistence;
using Xunit;

namespace SkyLeave.Application.Tests
{
    public class LeaveRequestServiceTests
    {
        private readonly DbContextOptions<SkyLeaveDbContext> _dbContextOptions;
        private readonly Mock<ILeaveRequestRepository> _mockLvRequestRepository;
        private readonly Mock<ILeaveBalanceRepository> _mockLvBalanceRepository;
        private readonly LeaveRequestService _service;

        public LeaveRequestServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<SkyLeaveDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _mockLvRequestRepository = new Mock<ILeaveRequestRepository>();
            _mockLvBalanceRepository = new Mock<ILeaveBalanceRepository>();
            _service = new LeaveRequestService(_mockLvRequestRepository.Object,_mockLvBalanceRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsEmptyList_WhenNoRecordsExist()
        {
            // Arrange
            _mockLvRequestRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<LeaveRequest>());

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsLeaveRequest_WhenIdExists()
        {
            // Arrange
            var leaveRequest = new LeaveRequest
            {
                Id = 1,
                EmployeeName = "Test User",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1),
                LeaveType = "Vacation",
                Status = "Pending"
            };
            _mockLvRequestRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(leaveRequest);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test User", result.EmployeeName);
        }

        [Fact]
        public async Task CreateAsync_AddsLeaveRequest()
        {
            // Arrange
            var leaveRequest = new LeaveRequest
            {
                EmployeeName = "Test User",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1),
                LeaveType = "Vacation",
                Status = "Pending"
            };
            _mockLvRequestRepository.Setup(repo => repo.Add(It.IsAny<LeaveRequest>())).Verifiable();
            _mockLvRequestRepository.Setup(repo => repo.SaveChangesAsync()).Returns(Task.CompletedTask);

            // Act
            var result = await _service.CreateAsync(leaveRequest);

            // Assert
            Assert.NotNull(result);
            _mockLvRequestRepository.Verify(repo => repo.Add(leaveRequest), Times.Once());
            _mockLvRequestRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once());
        }
    }
}