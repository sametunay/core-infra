using System;
using System.Net;
using System.Text.Json.Serialization;
using MyGallery.Core.Domain.Helper.Extensions;

namespace MyGallery.Core.Domain.Exceptions;

[Serializable]
public class HttpException
{
    private const string helpLink = "dev.mygallery.com/errors";
    
    public HttpException(HttpStatusCode statusCode, string message, string entityName)
    {
        StatusCode = statusCode;
        Message = message;
        EntityName = entityName;
    }

    public HttpException(HttpStatusCode statusCode, int errorCode, string message, string entityName)
    {
        StatusCode = statusCode;
        HelpLink = $"{helpLink}/{errorCode}";
        Message = message;
        EntityName = entityName;
    }

    public HttpException(int errorCode, string entityName = null)
    {
        StatusCode = errorCode.GetStatusCode();
        Message = errorCode.GetErrorMessage();
        HelpLink = $"{helpLink}/{errorCode}";
        EntityName = entityName;
    }

    public HttpException(int errorCode, string message, string entityName = null)
    {
        StatusCode = errorCode.GetStatusCode();
        Message = message;
        HelpLink = $"{helpLink}/{errorCode}";
        EntityName = entityName;
    }

    public HttpException(HttpStatusCode statusCode, string entityName = null)
    {
        StatusCode = statusCode;
        Message = statusCode.GetErrorMessage();
        HelpLink = $"{helpLink}/{statusCode.GetErrorCode()}";
        EntityName = entityName;
    }

    public HttpException(string message)
    {
        Message = message;
    }

    [JsonIgnore]
    public HttpStatusCode StatusCode { get; set; }
    public string HelpLink { get; set; }
    public string Message { get; set; }
    public string EntityName { get; set; }
}