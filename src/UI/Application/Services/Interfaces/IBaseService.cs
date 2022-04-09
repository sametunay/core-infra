using MyGallery.Core.Domain.Dto;
using MyGallery.Core.Domain.Entities;

namespace MyGallery.UI.Application.Services.Interfaces;

public interface IBaseService<TEntity, TKey> where TEntity : BaseEntity<TKey>, new() where TKey : unmanaged
{
    ListResultDto<TDto> GetAll<TDto>(PaginatorDto paginator, bool descending);
    Task<ObjectResultDto<TDto>> GetById<TDto>(TKey key);
}