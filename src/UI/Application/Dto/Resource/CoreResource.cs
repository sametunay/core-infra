using CI.Core.Domain.Enums;

namespace CI.UI.Application.Dto.Resource;

public record CoreResource
{
    public int Id { get; init; }
    public StatusEnum Status { get; set; }
}