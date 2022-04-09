namespace MyGallery.Core.Domain.ValueObjects
{
    public record PowerInfo
    {
        public Engine Engine { get; init; }
        public int MaxSpeed { get; init; }
    }
}