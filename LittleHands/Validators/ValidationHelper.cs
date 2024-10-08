using FluentValidation;
using LittleHands.CustomHttpExceptions;
using System.Net;

namespace LittleHands.Validators
{
    public class ValidationHelper
    {
        public static async Task ValidateAsync<T>(T model , IValidator<T> validator)
        {
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new CustomException(HttpStatusCode.BadRequest, $"Validation Failed : {errorMessage}");
            }
        }
    }
}
