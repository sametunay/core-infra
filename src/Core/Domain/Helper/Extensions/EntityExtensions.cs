using System;
using MyGallery.Core.Domain.Entities;
using MyGallery.Core.Domain.Exceptions;

namespace MyGallery.Core.Domain.Helper.Extensions;

public static class EntityExtensions
{
    public static void NullCheck<TEntity, TKey>(this TEntity entity) where TEntity : BaseEntity<TKey> where TKey : unmanaged
    {
        if(entity is null) throw new NotFoundException();
    }
}