using FluentValidation;
using SkyLeave.Domain.Entities;

namespace SkyLeave.API.Validators
{
    public class LeaveRequestValidator : AbstractValidator<LeaveRequest>
    {
        public LeaveRequestValidator()
        {
            RuleFor(x => x.EmployeeName)
                .NotEmpty().WithMessage("Employee name is required.")
                .Length(3, 100).WithMessage("Employee name must be between 3 and 100 characters.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date.");

            RuleFor(x => x.LeaveType)
                .NotEmpty().WithMessage("Leave type is required.")
                .Length(2, 50).WithMessage("Leave type must be between 2 and 50 characters.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => new[] { "Pending", "Approved", "Rejected" }.Contains(status))
                .WithMessage("Status must be 'Pending', 'Approved', or 'Rejected'.");
        }
    }
}