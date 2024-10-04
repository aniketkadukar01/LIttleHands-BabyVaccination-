using FluentValidation;
using LittleHands.Models;

namespace LittleHands.Validators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator() 
        {
            RuleFor(a => a.ChildrenID)
                .NotEmpty().WithMessage("Children Id is required.");

            RuleFor(a => a.DoctorId)
                .NotEmpty().WithMessage("Doctor Id is required.");

            RuleFor(a => a.AppointmentDate)
                .NotEmpty().WithMessage("AppointmentDate is required.")
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now.Date))
                .WithMessage("Appointment date must be today or in the future.");

            RuleFor(a => a.AppointmentTime)
                .NotEmpty().WithMessage("Appointment time is required.");

            RuleFor(a => a.Status)
                .NotEmpty().WithMessage("Status is required.")
                .IsInEnum().WithMessage("Invalid Status type selected.");

            RuleFor(a => a.VaccineId)
                .NotEmpty().WithMessage("Vaccine Id is required.");
        }
    }
}
