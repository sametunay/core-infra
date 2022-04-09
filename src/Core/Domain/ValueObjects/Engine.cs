namespace MyGallery.Core.Domain.ValueObjects
{
    public record Engine
    {
        public string Type { get; init; }
        public string Transmission { get; init; }
        public int? CylinderVolume { get; init; }
        public int? MaxPower { get; init; }
        public int? MaxTorque { get; init; }
    }
}