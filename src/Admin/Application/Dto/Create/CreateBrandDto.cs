namespace CI.Admin.Application.Dto.Create;

public record CreateBrandDto
{
    public string Title { get; init; }
    public string National { get; init; }
}