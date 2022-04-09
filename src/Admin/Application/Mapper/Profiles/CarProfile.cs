using AutoMapper;
using MyGallery.Admin.Application.Dto.Create;
using MyGallery.Admin.Application.Dto.Resource;
using MyGallery.Admin.Application.Dto.Update;
using MyGallery.Core.Domain.Entities;

namespace MyGallery.Admin.Application.Mapper.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CreateCarDto>().ReverseMap();
        CreateMap<Car, UpdateCarDto>().ReverseMap();
        CreateMap<Car, CarResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}