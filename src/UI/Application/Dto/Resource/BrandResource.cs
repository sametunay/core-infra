namespace CI.UI.Application.Dto.Resource;

public record BrandResource : CoreResource
{
    public string Title { get; init; }
    public string National { get; init; }
}