using System.ComponentModel;

namespace CI.Core.Domain.Enums
{
    public enum StatusEnum
    {
        [Description("Pasif")]
        Passive = 0,
        [Description("Aktif")]
        Active = 1,
        [Description("Taslak")]
        Draft = 2,
        [Description("Silinmiş")]
        Deleted = 8
    }
}