namespace SkyLeave.Domain.Entities
{
    public class LeaveBalance
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key to Users
        public string LeaveType { get; set; } = default!;
        public int AvailableDays { get; set; }
        public User User { get; set; } = default!; // Navigation property
    }
}
