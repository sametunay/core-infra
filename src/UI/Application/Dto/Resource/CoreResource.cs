using MyGallery.Core.Domain.Enums;

namespace MyGallery.UI.Application.Dto.Resource;

public record CoreResource
{
    public int Id { get; init; }
    public StatusEnum Status { get; set; }
}