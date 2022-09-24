using CI.Core.Data.Contexts.EF;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructor.Repositories.Interfaces;

namespace CI.Core.Infrastructor.Repositories.Implementation
{
    public class BrandRepository : BaseRepository<Brand, int>, IBrandRepository
    {
        public BrandRepository(EFContext context) : base(context)
        {
        }
    }
}