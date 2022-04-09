using AutoMapper;
using MyGallery.Core.Domain.Entities;
using MyGallery.Core.Infrastructor.Repositories.Interfaces;
using MyGallery.UI.Application.Services.Interfaces;

namespace MyGallery.UI.Application.Services.Imlementation;

public class CarCategoryService : BaseService<CarCategory, int>, ICarCategoryService
{
    public CarCategoryService(ICarCategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}