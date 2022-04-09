using MyGallery.Admin.Application.Dto;
using MyGallery.Admin.Application.Dto.Resource;
using MyGallery.Core.Domain.Dto;
using MyGallery.Core.Domain.Entities;

namespace MyGallery.Admin.Application.Service.Interfaces;

public interface IBaseService<in TEntity, in TKey, TResult> where TEntity : BaseEntity<TKey>, new() where TKey : unmanaged where TResult : ResultDto, new()
{
    Task<TResult> CreateAsync<TDto>(TDto dto);
    Task<TResult> UpdateAsync<TDto>(TKey key, TDto dto);
    Task<TResult> SoftDeleteAsync(TKey key);
    Task<ObjectResultDto<TResource>> GetByIdAsync<TResource>(TKey key) where TResource : CoreResource;
    Task<ListResultDto<TResource>> ListAsync<TResource>(PaginatorDto paginator) where TResource : CoreResource;
}