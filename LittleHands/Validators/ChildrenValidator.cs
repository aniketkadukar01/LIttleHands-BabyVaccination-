using FluentValidation;
using LittleHands.Data;
using LittleHands.Models;
using Microsoft.EntityFrameworkCore;

namespace LittleHands.Validators
{
    public class ChildrenValidator : AbstractValidator<Children>
    {
        private readonly LittleHandsContext _context;

        public ChildrenValidator(LittleHandsContext context) 
        {
            _context = context;

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
                .NotEmpty().WithMessage("Parent ID is required.")
                .MustAsync(ParentExists).WithMessage("Parent with the specified ID does not exist.");

            RuleFor(c => c.Parent)
                .NotNull().WithMessage("Parent is required.");

        }

        private async Task<bool> ParentExists(int parentId , CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(u => u.Id == parentId , cancellationToken);
        }
    }
}
