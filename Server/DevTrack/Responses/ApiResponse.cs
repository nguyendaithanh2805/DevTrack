namespace DevTrack.Responses
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public ApiResponse(bool status, string? message, T? data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public static ApiResponse<T> Success(T data, string message = "Get data successfully.")
        {
            return new ApiResponse<T>(true, message, data);
        }
        public static ApiResponse<T> Fail(string message, T? data = default)
        {
            return new ApiResponse<T>(false, message, data);
        }
    }
}
