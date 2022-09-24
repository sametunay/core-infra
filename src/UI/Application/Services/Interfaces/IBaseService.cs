using CI.Core.Domain.Dto;
using CI.Core.Domain.Entities;

namespace CI.UI.Application.Services.Interfaces;

public interface IBaseService<TEntity, TKey> where TEntity : BaseEntity<TKey>, new() where TKey : unmanaged
{
    ListResultDto<TDto> GetAll<TDto>(PaginatorDto paginator, bool descending);
    Task<ObjectResultDto<TDto>> GetById<TDto>(TKey key);
}