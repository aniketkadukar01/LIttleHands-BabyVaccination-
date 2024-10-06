namespace LittleHands.DataModels
{
    public class ErrorResponse
    {
        public required int StatusCode { get; set; }
        public required string Message { get; set; }
        public string? Detailed { get; set; }
        public string? StackTrace { get; set; }
    }
}
