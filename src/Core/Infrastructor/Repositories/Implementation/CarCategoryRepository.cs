using MyGallery.Core.Data.Contexts.EF;
using MyGallery.Core.Domain.Entities;
using MyGallery.Core.Infrastructor.Repositories.Interfaces;

namespace MyGallery.Core.Infrastructor.Repositories.Implementation
{
    public class CarCategoryRepository : BaseRepository<CarCategory, int>, ICarCategoryRepository
    {
        public CarCategoryRepository(EFContext context) : base(context)
        {
        }
    }
}