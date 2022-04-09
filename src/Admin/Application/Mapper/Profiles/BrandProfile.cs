using AutoMapper;
using MyGallery.Admin.Application.Dto.Create;
using MyGallery.Admin.Application.Dto.Resource;
using MyGallery.Admin.Application.Dto.Update;
using MyGallery.Core.Domain.Entities;

namespace MyGallery.Admin.Application.Mapper.Profiles;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, CreateBrandDto>().ReverseMap();
        CreateMap<Brand, UpdateBrandDto>().ReverseMap();
        CreateMap<Brand, BrandResource>().AfterMap((src, dest) => dest.Status = src.Audit.Status).ReverseMap();
    }
}