// src/SkyLeave.Domain/Entities/LeaveRequest.cs
namespace SkyLeave.Domain.Entities;

public class LeaveRequest
{
    public int Id { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public string EmployeeName { get; set; } = string.Empty;
    public int Days { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveType { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
}
