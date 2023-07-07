namespace API.Helpers.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Your request is incorrect.",
                401 => "User not authorized.",
                404 => "Requested resource was not found.",
                405 => "Method HTTP not allowed in the server.",
                500 => "Internal server error. Please contact the administrator."
            };
        }
    }
}
