using CI.Admin.Application.Dto.Create;

namespace CI.Admin.Application.Dto.Update;

public record UpdateCarDto : CreateCarDto
{    
    public StatusEnum Status { get; set; }
}