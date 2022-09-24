using AutoMapper;
using CI.Admin.Application.Dto.Create;
using CI.Admin.Application.Dto.Resource;
using CI.Admin.Application.Dto.Update;
using CI.Core.Domain.Entities;

namespace CI.Admin.Application.Mapper.Profiles;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, CreateBrandDto>().ReverseMap();
        CreateMap<Brand, UpdateBrandDto>().ReverseMap();
        CreateMap<Brand, BrandResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}