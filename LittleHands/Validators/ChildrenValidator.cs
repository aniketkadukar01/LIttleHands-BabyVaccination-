using FluentValidation;
using LittleHands.Models;

namespace LittleHands.Validators
{
    public class ChildrenValidator : AbstractValidator<Children>
    {
        public ChildrenValidator() 
        {
            RuleFor(c => c.DateOfBirth)
                .NotEmpty().WithMessage("Date of Birth is required.")
                .LessThan(DateOnly.FromDateTime(DateTime.Now.Date))
                .WithMessage("Date of Birth must be in the past.");

            RuleFor(c => c.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .IsInEnum().WithMessage("Invalid gender selected.");

            RuleFor(c => c.BloodType)
                .NotEmpty().WithMessage("Blood Type is required.")
                .IsInEnum().WithMessage("Invalid blood type selected.");

            RuleFor(c => c.ParentId)
                .NotEmpty().WithMessage("Parent ID is required.");
        }
    }
}
