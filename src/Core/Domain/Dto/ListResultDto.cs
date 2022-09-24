using System.Collections.Generic;
using CI.Core.Domain.Helper.Extensions;

namespace CI.Core.Domain.Dto;

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