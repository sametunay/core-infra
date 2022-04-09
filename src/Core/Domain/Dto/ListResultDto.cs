using System.Collections.Generic;
using MyGallery.Core.Domain.Helper.Extensions;

namespace MyGallery.Core.Domain.Dto;

public record ListResultDto<TResult> : ResultDto
{
    protected ListResultDto(ResultDto original) : base(original)
    {
    }

    public ListResultDto(List<TResult> data, int pageIndex, int pageSize, long totalCount)
    {
        Data = data;
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalCount = totalCount;
        PageCount = PaginationExtensions.CalculatePagesCount(totalCount, pageSize);
    }

    public List<TResult> Data { get; init; }
    public int PageIndex { get; init; }
    public int PageSize { get; init; }
    public int PageCount { get; init; }
    public long TotalCount { get; init; }
}