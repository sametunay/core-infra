using MyGallery.Admin.Application.Dto.Create;
using MyGallery.Core.Domain.Enums;

namespace MyGallery.Admin.Application.Dto.Update;

public record UpdateCarCategoryDto : CreateCarCategoryDto
{
    public StatusEnum Status { get; init; }
}