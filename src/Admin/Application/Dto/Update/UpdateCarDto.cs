using MyGallery.Admin.Application.Dto.Create;

namespace MyGallery.Admin.Application.Dto.Update;

public record UpdateCarDto : CreateCarDto
{    
    public StatusEnum Status { get; set; }
}