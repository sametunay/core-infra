namespace MyGallery.Core.Domain.Dto
{
    public record PaginatorDto
    {
        public int PageIndex { get; init; } = 0;
        
        public int PageSize { get; init; } = 25;
    }
}