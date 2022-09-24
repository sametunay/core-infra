global using CI.Core.Domain.Enums;
using AutoMapper;
using CI.Admin.Application.Dto;
using CI.Admin.Application.Dto.Resource;
using CI.Admin.Application.Service.Interfaces;
using CI.Core.Domain.Dto;
using CI.Core.Domain.Entities;
using CI.Core.Domain.Exceptions;
using CI.Core.Domain.Helper.Extensions;
using CI.Core.Infrastructor.Repositories.Interfaces;

namespace CI.Admin.Application.Service.Implementation;

public class BaseService<TEntity, TKey, TResult> : IBaseService<TEntity, TKey, TResult> where TEntity : BaseEntity<TKey>, new() where TKey : unmanaged where TResult : ResultDto, new()
{
    private readonly IBaseRepository<TEntity, TKey> _repository;
    private readonly IMapper _mapper;

    public BaseService(IBaseRepository<TEntity, TKey> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<TResult> CreateAsync<TDto>(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto, e => e.AfterMap((src, dest) => dest.CreateAudit()));

        entity.Audit.SetStatus(StatusEnum.Active);

        await _repository.CreateAsync(entity);

        return (TResult)new ResultDto(success: true);
    }

    public virtual async Task<TResult> UpdateAsync<TDto>(TKey key, TDto dto)
    {
        var entity = await _repository.GetByIdAsync(key);

        entity.NullCheck<TEntity, TKey>();

        var updated = _mapper.Map<TEntity>(entity);

        await _repository.UpdateAsync(updated);

        return (TResult)new ResultDto(success: true);
    }

    public virtual async Task<TResult> SoftDeleteAsync(TKey key)
    {
        var entity = await _repository.GetByIdAsync(key);

        entity.NullCheck<TEntity, TKey>();

        await _repository.SoftDeleteAsync(entity);

        return (TResult)new ResultDto(success: true);
    }

    public virtual async Task<ObjectResultDto<TResource>> GetByIdAsync<TResource>(TKey key) where TResource : CoreResource
    {
        var entity = await _repository.GetByIdAsync(key);

        entity.NullCheck<TEntity, TKey>();

        var response = _mapper.Map<TResource>(entity);

        return new ObjectResultDto<TResource>(response);
    }

    public virtual async Task<ListResultDto<TResource>> ListAsync<TResource>(PaginatorDto paginator) where TResource : CoreResource
    {
        var entities = _repository.Filter(paginator.PageIndex, paginator.PageSize, entity => entity.Audit.Status.Equals(StatusEnum.Active));

        var data = _mapper.Map<List<TResource>>(entities);

        var totalCount = await _repository.CountAsync();

        return new ListResultDto<TResource>(data, paginator.PageIndex, paginator.PageSize, totalCount);
    }

    public virtual async Task IdCheck<TForeignEntity, TForeignKey, TRepository>(TForeignKey key, TRepository foreignRepository) where TForeignKey : unmanaged where TForeignEntity : BaseEntity<TForeignKey>, new() where TRepository : IBaseRepository<TForeignEntity, TForeignKey>
    {
        if (await foreignRepository.AnyAsync(key) == false) throw new NotFoundException(entityName: typeof(TForeignEntity).Name);
    }
}