using AutoMapper;
using CI.Admin.Application.Service.Interfaces;
using CI.Core.Domain.Dto;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructor.Repositories.Interfaces;

namespace CI.Admin.Application.Service.Implementation;

public class CarCategoryService : BaseService<CarCategory, int, ResultDto>, ICarCategoryService
{
    public CarCategoryService(ICarCategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}