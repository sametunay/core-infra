using AutoMapper;
using MyGallery.Admin.Application.Dto.Create;
using MyGallery.Admin.Application.Dto.Resource;
using MyGallery.Admin.Application.Dto.Update;
using MyGallery.Core.Domain.Entities;

namespace MyGallery.Admin.Application.Mapper.Profiles;

public class CarCategoryProfile : Profile
{
    public CarCategoryProfile()
    {
        CreateMap<CarCategory, CreateCarCategoryDto>().ReverseMap();
        CreateMap<CarCategory, UpdateCarCategoryDto>().ReverseMap();
        CreateMap<CarCategory, CarCategoryResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}