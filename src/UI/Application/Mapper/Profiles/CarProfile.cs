using AutoMapper;
using CI.Core.Domain.Entities;
using CI.UI.Application.Dto.Resource;

namespace CI.UI.Application.Mapper.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}