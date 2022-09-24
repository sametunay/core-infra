using System;
using System.Net;
using CI.Core.Domain.Exceptions;
using CI.Core.Domain.Exceptions.Messages;

namespace CI.Core.Domain.Helper.Extensions;

public static class ExceptionExtensions
{
    public static HttpException HttpMap(this Exception exception)
    {
        if (exception.GetType().IsSubclassOf(typeof(BaseException)))
            return new HttpException(errorCode: (exception as BaseException).ErrorCode, entityName: (exception as BaseException).EntityName);

        return new HttpException(HttpStatusCode.InternalServerError);
    }

    public static HttpStatusCode GetStatusCode(this int errorCode)
    {
        return InMemoryExceptionMessages.Messages.Find(x => x.ErrorCode.Equals(errorCode))?.StatusCode ?? HttpStatusCode.InternalServerError;
    }

    public static HttpStatusCode GetStatusCode(this string message)
    {
        return InMemoryExceptionMessages.Messages.Find(x => x.Message.Equals(message))?.StatusCode ?? HttpStatusCode.InternalServerError;
    }

    public static string GetErrorMessage(this int errorCode)
    {
        return InMemoryExceptionMessages.Messages.Find(x => x.ErrorCode.Equals(errorCode))?.Message;
    }

    public static string GetErrorMessage(this HttpStatusCode statusCode)
    {
        return InMemoryExceptionMessages.Messages.Find(x => x.StatusCode.Equals(statusCode))?.Message;
    }

    public static int GetErrorCode(this HttpStatusCode statusCode)
    {
        return InMemoryExceptionMessages.Messages.Find(x => x.StatusCode.Equals(statusCode))?.ErrorCode ?? (int)HttpStatusCode.InternalServerError;
    }
}