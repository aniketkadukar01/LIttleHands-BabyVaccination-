using FluentValidation;
using LittleHands.Models;

namespace LittleHands.Validators
{
    public class VaccineTypeValidator : AbstractValidator<VaccineType>
    {
        public VaccineTypeValidator() 
        {
            RuleFor(v => v.VaccineName)
                .NotEmpty().WithMessage("Vaccine Name is required.");

            RuleFor(v => v.VaccineDescription)
                .NotEmpty().WithMessage("VaccineDescription is required.");
        }
    }
}
