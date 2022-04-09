using AutoMapper;
using MyGallery.Core.Domain.Entities;
using MyGallery.UI.Application.Dto.Resource;

namespace MyGallery.UI.Application.Mapper.Profiles;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, BrandResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}