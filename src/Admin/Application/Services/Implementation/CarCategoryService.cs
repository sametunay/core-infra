using AutoMapper;
using MyGallery.Admin.Application.Service.Interfaces;
using MyGallery.Core.Domain.Dto;
using MyGallery.Core.Domain.Entities;
using MyGallery.Core.Infrastructor.Repositories.Interfaces;

namespace MyGallery.Admin.Application.Service.Implementation;

public class CarCategoryService : BaseService<CarCategory, int, ResultDto>, ICarCategoryService
{
    public CarCategoryService(ICarCategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}