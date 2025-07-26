// src/SkyLeave.Domain/Entities/LeaveRequest.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyLeave.Domain.Entities
{
    public class LeaveRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeeId { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string EmployeeName { get; set; } = string.Empty;

        [Range(1, 365)]
        public int Days { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string LeaveType { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending";
    }
}
