using System.Collections.Generic;
using System.Net;

namespace CI.Core.Domain.Exceptions.Messages;

public static class InMemoryExceptionMessages
{
    public record HttpExceptionMessage
    {
        public int ErrorCode { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public HttpExceptionMessage(int errorCode, HttpStatusCode statusCode, string message)
        {
            this.ErrorCode = errorCode;
            this.StatusCode = statusCode;
            this.Message = message;
        }
    }

    public static List<HttpExceptionMessage> Messages = new List<HttpExceptionMessage>()
        {
            new HttpExceptionMessage(4000, HttpStatusCode.NotFound, "Bulunamadı"),
            new HttpExceptionMessage(5000, HttpStatusCode.InternalServerError, "Sistemde geçici bir hata oluştu.")
        };

}