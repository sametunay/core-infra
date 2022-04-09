using System;
using MyGallery.Core.Domain.ValueObjects;

namespace MyGallery.Core.Domain.Entities
{
    public abstract class BaseEntity<TKey> : ICloneable where TKey: unmanaged
    {
        public TKey Id { get; set; }
        public Audit Audit { get; protected set; }

        public void CreateAudit()
        {
            Audit = new Audit();
        }

        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
    }
}
