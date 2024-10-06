using LittleHands.CustomHttpExceptions;
using LittleHands.DataModels;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace LittleHands.MIddleWareExtensions
{
    public class ExceptionHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        private readonly ILogger<ExceptionHandlingMiddleWare> _logger;

        public ExceptionHandlingMiddleWare(RequestDelegate next , IHostEnvironment env , ILogger<ExceptionHandlingMiddleWare> logger)
        {
            _env = env;
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Default status code and message
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string message = "Internal Server Error. Please try again later.";

            // Check if the thrown exception is a CustomHttpException
            if(exception is CustomException customException)
            {
                statusCode = customException.StatusCode;
                message = customException.Message;
            }

            // Log the exception details
            _logger.LogError(exception, $"An Error is occured : {exception.Message}");

            // Prepare the response based on the environment (Development vs Production)
            var response = _env.IsDevelopment()
                ? new ErrorResponse
                {
                    StatusCode = (int)statusCode,
                    Message = message,
                    Detailed = exception.Message,
                    StackTrace = exception.StackTrace
                }
                : new ErrorResponse
                {
                    StatusCode = (int)statusCode,
                    Message = message,
                };

            // Set the response content type and status code
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var jsonresponse = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(jsonresponse);

        }

    }
}
