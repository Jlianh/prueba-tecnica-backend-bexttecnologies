using System.Net;

namespace BxtGeography.Responses
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> Ok(T data, string? message = null)
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                StatusCode = (int)HttpStatusCode.OK,
                Message = message ?? "Success",
                Data = data
            };
        }

        public static ApiResponse<T> Fail(string message, int StatusCode)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Message = message,
                StatusCode = StatusCode,
            };
        }
    }
}
