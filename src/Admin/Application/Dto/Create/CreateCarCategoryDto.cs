namespace CI.Admin.Application.Dto.Create;

public record CreateCarCategoryDto
{
    public string Title { get; init; }
    public string Description { get; init; }
}