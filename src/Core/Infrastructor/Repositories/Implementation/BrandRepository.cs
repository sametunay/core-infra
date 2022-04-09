using MyGallery.Core.Data.Contexts.EF;
using MyGallery.Core.Domain.Entities;
using MyGallery.Core.Infrastructor.Repositories.Interfaces;

namespace MyGallery.Core.Infrastructor.Repositories.Implementation
{
    public class BrandRepository : BaseRepository<Brand, int>, IBrandRepository
    {
        public BrandRepository(EFContext context) : base(context)
        {
        }
    }
}