using AutoMapper;
using CI.Admin.Application.Dto.Create;
using CI.Admin.Application.Dto.Resource;
using CI.Admin.Application.Dto.Update;
using CI.Core.Domain.Entities;

namespace CI.Admin.Application.Mapper.Profiles;

public class CarCategoryProfile : Profile
{
    public CarCategoryProfile()
    {
        CreateMap<CarCategory, CreateCarCategoryDto>().ReverseMap();
        CreateMap<CarCategory, UpdateCarCategoryDto>().ReverseMap();
        CreateMap<CarCategory, CarCategoryResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}