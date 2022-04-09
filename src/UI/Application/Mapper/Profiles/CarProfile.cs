using AutoMapper;
using MyGallery.Core.Domain.Entities;
using MyGallery.UI.Application.Dto.Resource;

namespace MyGallery.UI.Application.Mapper.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}