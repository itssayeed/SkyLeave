namespace SkyLeave.Domain.Entities
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}