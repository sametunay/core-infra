using CI.Admin.Application.Dto.Create;
using CI.Core.Domain.Enums;

namespace CI.Admin.Application.Dto.Update;

public record UpdateBrandDto : CreateBrandDto
{
    public StatusEnum? Status { get; init; } = StatusEnum.Active;
}