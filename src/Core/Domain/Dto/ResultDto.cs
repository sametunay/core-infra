namespace CI.Core.Domain.Dto;

public record ResultDto
{
    public bool Success { get; init; }
    public int? ErrorCode { get; init; }
    public string Message { get; init; }

    public ResultDto()
    {
        Success = true;
    }
    
    public ResultDto(bool success)
    {
        Success = success;
    }

    public ResultDto(int errorCode)
    {
        ErrorCode = errorCode;
        Success = false;
    }

    public ResultDto(int errorCode, string message)
    {
        ErrorCode = errorCode;
        Success = false;
        Message = message;
    }

    public ResultDto(bool success, int? errorCode, string message)
    {
        Success = success;
        ErrorCode = errorCode;
        Message = message;
    }

    public bool IsSuccess()
    {
        return Success;
    }
}