using AutoMapper;
using CI.Core.Domain.Entities;
using CI.UI.Application.Dto.Resource;

namespace CI.UI.Application.Mapper.Profiles;

public class CarCategoryProfile : Profile
{
    public CarCategoryProfile()
    {
        CreateMap<CarCategory, CarCategoryResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}