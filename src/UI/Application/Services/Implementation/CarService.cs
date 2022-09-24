using AutoMapper;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructure.Repositories.Interfaces;
using CI.UI.Application.Services.Interfaces;

namespace CI.UI.Application.Services.Imlementation;

public class CarService : BaseService<Car, int>, ICarService
{
    public CarService(ICarRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}