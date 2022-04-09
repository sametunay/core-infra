using MyGallery.Admin.Application.Dto.Create;
using MyGallery.Core.Domain.Enums;

namespace MyGallery.Admin.Application.Dto.Update;

public record UpdateBrandDto : CreateBrandDto
{
    public StatusEnum? Status { get; init; } = StatusEnum.Active;
}