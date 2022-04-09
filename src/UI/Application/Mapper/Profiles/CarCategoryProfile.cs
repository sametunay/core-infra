using AutoMapper;
using MyGallery.Core.Domain.Entities;
using MyGallery.UI.Application.Dto.Resource;

namespace MyGallery.UI.Application.Mapper.Profiles;

public class CarCategoryProfile : Profile
{
    public CarCategoryProfile()
    {
        CreateMap<CarCategory, CarCategoryResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}