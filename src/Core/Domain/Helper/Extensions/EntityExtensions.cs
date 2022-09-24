using System;
using CI.Core.Domain.Entities;
using CI.Core.Domain.Exceptions;

namespace CI.Core.Domain.Helper.Extensions;

public static class EntityExtensions
{
    public static void NullCheck<TEntity, TKey>(this TEntity entity) where TEntity : BaseEntity<TKey> where TKey : unmanaged
    {
        if(entity is null) throw new NotFoundException();
    }
}