using System;
using MyGallery.Core.Domain.Enums;

namespace MyGallery.Core.Domain.ValueObjects
{
    public class Audit
    {
        public DateTimeOffset CreatedAt { get; protected set; }
		public string CreatedBy { get; protected set; }
		public DateTimeOffset? ModifiedAt { get; protected set; }
		public string ModifiedBy { get; protected set; }
		public StatusEnum Status { get; protected set; }

        public Audit()
        {
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public void SetStatus(StatusEnum status)
        {
            Status = status;
        }

        public void SoftDelete()
        {
            Status = StatusEnum.Deleted;
            ModifiedAt = DateTimeOffset.UtcNow;
        }

        public string GetCreatedAtString()
        {
          return CreatedAt.ToString("dd.MM.yyyy");
        }

        public string GetModifiedAtString()
        {
          return ModifiedAt?.ToString("dd.MM.yyyy");
        }
    }
}