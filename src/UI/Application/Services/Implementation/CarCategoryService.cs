using AutoMapper;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructure.Repositories.Interfaces;
using CI.UI.Application.Services.Interfaces;

namespace CI.UI.Application.Services.Imlementation;

public class CarCategoryService : BaseService<CarCategory, int>, ICarCategoryService
{
    public CarCategoryService(ICarCategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}