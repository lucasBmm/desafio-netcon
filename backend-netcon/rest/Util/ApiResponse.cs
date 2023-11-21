namespace rest.Util
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime DateTime { get; set; }
        public string? Value { get; set; }

        public static ApiResponse BadRequestResponse(string errorMessage)
        {
            return new ApiResponse
            {
                StatusCode = 400,
                ErrorMessage = errorMessage,
                DateTime = DateTime.Now,
                Value = null
            };
        }

        public static ApiResponse SuccessResponse(double value, string unit)
        {
            return new ApiResponse
            {
                StatusCode = 200,
                ErrorMessage = null,
                DateTime = DateTime.Now,
                Value = $"{value} {unit}"
            };
        }
    }
}
