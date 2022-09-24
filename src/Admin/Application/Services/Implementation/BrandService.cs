using AutoMapper;
using CI.Admin.Application.Service.Interfaces;
using CI.Core.Domain.Dto;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructure.Repositories.Interfaces;

namespace CI.Admin.Application.Service.Implementation;

public class BrandService : BaseService<Brand, int, ResultDto>, IBrandService
{
    public BrandService(IBrandRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}