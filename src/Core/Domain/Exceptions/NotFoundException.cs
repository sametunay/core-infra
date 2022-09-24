using System;

namespace CI.Core.Domain.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(int errorCode = 4000) : base(errorCode)
    {
    }

    public NotFoundException(string entityName, string message, int errorCode = 4000) : base(errorCode, message, entityName)
    {
        
    }

    public NotFoundException(string entityName, int errorCode = 4000) : base(errorCode, entityName)
    {
        
    }
}