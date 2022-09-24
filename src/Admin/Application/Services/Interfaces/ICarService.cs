using CI.Core.Domain.Dto;
using CI.Core.Domain.Entities;

namespace CI.Admin.Application.Service.Interfaces
{
    public interface ICarService : IBaseService<Car, int, ResultDto>
    {
    }
}