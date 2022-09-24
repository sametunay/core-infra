using AutoMapper;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructor.Repositories.Interfaces;
using CI.UI.Application.Services.Interfaces;

namespace CI.UI.Application.Services.Imlementation;

public class BrandService : BaseService<Brand, int>, IBrandService
{
    public BrandService(IBrandRepository repository, IMapper mapper) : base(repository, mapper)
    {

    }
}