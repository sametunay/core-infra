using AutoMapper;
using CI.Core.Domain.Entities;
using CI.UI.Application.Dto.Resource;

namespace CI.UI.Application.Mapper.Profiles;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, BrandResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}