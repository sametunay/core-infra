namespace MyGallery.Admin.Application.Dto.Resource;

public record CarCategoryResource : CoreResource
{
    public string Title { get; init; }
    public string Description { get; init; }
}