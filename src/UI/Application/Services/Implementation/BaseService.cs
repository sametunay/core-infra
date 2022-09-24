using AutoMapper;
using CI.Core.Domain.Dto;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructure.Repositories.Interfaces;
using CI.UI.Application.Services.Interfaces;

namespace CI.UI.Application.Services.Imlementation;

public abstract class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey> where TEntity : BaseEntity<TKey>, new() where TKey : unmanaged
{
    private readonly IBaseRepository<TEntity, TKey> _repository;
    private readonly IMapper _mapper;

    protected BaseService(IBaseRepository<TEntity, TKey> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ListResultDto<TDto> GetAll<TDto>(PaginatorDto paginator, bool descending)
    {
        var entities = _repository.Filter(paginator.PageIndex, paginator.PageSize, descending: descending);

        var data = _mapper.Map<List<TDto>>(entities);

        return new ListResultDto<TDto>(data, paginator.PageIndex, paginator.PageSize, entities.LongCount());
    }

    public async Task<ObjectResultDto<TDto>> GetById<TDto>(TKey key)
    {
        var entity = await _repository.GetByIdAsync(key);

        var data = _mapper.Map<TDto>(entity);

        return new ObjectResultDto<TDto>(data);
    }
}