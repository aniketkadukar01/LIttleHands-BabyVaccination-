using FluentValidation;
using LittleHands.Data;
using LittleHands.Models;
using Microsoft.EntityFrameworkCore;

namespace LittleHands.Validators
{
    public class UserValidator : AbstractValidator<User>
    {

        private readonly LittleHandsContext _context;

        public UserValidator(LittleHandsContext context)
        {
            _context = context;

            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required.");

            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required.");

            RuleFor(u => u.ContactNumber)
                .NotEmpty().WithMessage("Contact Number is required.")
                .Matches(@"^\d{10}$").WithMessage("Please enter a valid 10-digit phone number.")
                .MustAsync(BeUniqueContactNumber).WithMessage("Contact Number is already in use.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MustAsync(BeUniqueEmail).WithMessage("Email is already in use.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(u => u.Role)
                .IsInEnum().WithMessage("Invalid role.");

        }

        private async Task<bool> BeUniqueContactNumber(string contactNumber , CancellationToken cancellationToken)
        {
            return !await _context.Users.AnyAsync(u => u.ContactNumber == contactNumber , cancellationToken);
        }

        private async Task<bool> BeUniqueEmail(string email , CancellationToken cancellationToken)
        {
            return !await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
        }
    }
}
