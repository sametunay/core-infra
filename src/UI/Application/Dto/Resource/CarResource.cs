using CI.Core.Domain.ValueObjects;

namespace CI.UI.Application.Dto.Resource;

public record CarResource : CoreResource
{
    public string Name { get; init; }
    public string Description { get; init; }
    public string CaseType { get; init; }
    public int CarCategoryId { get; init; }
    public int BrandId { get; init; }
    public PowerInfo PowerInfo { get; init; }
}