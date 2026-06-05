using OrderFlow.Application.Abstractions.Common;

namespace OrderFlow.Presentation.Common.Responses;

public class ApiResponse<T>
{
    public bool Success { get; init; }
    public T? Data { get; init; }
    public IReadOnlyCollection<Error>? Errors { get; init; } = [];

    public static ApiResponse<T> SuccessResponse(T data)
    {
        return new()
        {
            Success = true,
            Data = data
        };
    }

    public static ApiResponse<T> FailureResponse(Error error)
    {
        return new()
        {
            Success = false,
            Errors = [error]
        };
    }
}
