namespace CI.Core.Domain.Dto;

public record ObjectResultDto<TData> : ResultDto
{
    protected ObjectResultDto(ResultDto original) : base(original)
    {

    }

    public ObjectResultDto(TData data)
    {
        Data = data;
    }

    public TData Data { get; init; }
}