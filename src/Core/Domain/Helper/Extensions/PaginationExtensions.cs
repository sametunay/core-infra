using System;

namespace MyGallery.Core.Domain.Helper.Extensions;

public static class PaginationExtensions
{
    public static int CalculatePagesCount(long totalCount, int pageSize)
    {
        return (int) Math.Ceiling((double) totalCount / pageSize);
    }
}