using System;

namespace CI.Core.Domain.Exceptions;

[Serializable]
public class BaseException : Exception
{
    public BaseException(int errorCode, string message, string entityName) : base(message)
    {
        ErrorCode = errorCode;
        EntityName = entityName;
    }

    public BaseException(int errorCode)
    {
        ErrorCode = errorCode;
    }

    public BaseException(int errorCode, string entityName)
    {
        ErrorCode = errorCode;
        EntityName = entityName;
    }

    public BaseException(string message) : base(message)
    {
    }

    public int ErrorCode { get; set; }
    public string EntityName { get; set; }
}