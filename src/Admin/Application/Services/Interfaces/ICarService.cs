using MyGallery.Core.Domain.Dto;
using MyGallery.Core.Domain.Entities;

namespace MyGallery.Admin.Application.Service.Interfaces
{
    public interface ICarService : IBaseService<Car, int, ResultDto>
    {
    }
}