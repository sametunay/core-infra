using CI.Admin.Application.Dto;
using CI.Admin.Application.Dto.Resource;
using CI.Core.Domain.Dto;
using CI.Core.Domain.Entities;

namespace CI.Admin.Application.Service.Interfaces;

public interface IBaseService<in TEntity, in TKey, TResult> where TEntity : BaseEntity<TKey>, new() where TKey : unmanaged where TResult : ResultDto, new()
{
    Task<TResult> CreateAsync<TDto>(TDto dto);
    Task<TResult> UpdateAsync<TDto>(TKey key, TDto dto);
    Task<TResult> SoftDeleteAsync(TKey key);
    Task<ObjectResultDto<TResource>> GetByIdAsync<TResource>(TKey key) where TResource : CoreResource;
    Task<ListResultDto<TResource>> ListAsync<TResource>(PaginatorDto paginator) where TResource : CoreResource;
}