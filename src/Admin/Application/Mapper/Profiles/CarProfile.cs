using AutoMapper;
using CI.Admin.Application.Dto.Create;
using CI.Admin.Application.Dto.Resource;
using CI.Admin.Application.Dto.Update;
using CI.Core.Domain.Entities;

namespace CI.Admin.Application.Mapper.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CreateCarDto>().ReverseMap();
        CreateMap<Car, UpdateCarDto>().ReverseMap();
        CreateMap<Car, CarResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}