using System.ComponentModel.DataAnnotations;

namespace SkyLeave.Application.DTOs
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; } = default!;
        public string Status { get; set; } = default!;
    }

    public class CreateLeaveRequestDto
    {
        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; } = default!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string LeaveType { get; set; } = default!;
    }
}