using MyGallery.Core.Data.Contexts.EF;
using MyGallery.Core.Domain.Entities;
using MyGallery.Core.Infrastructor.Repositories.Interfaces;

namespace MyGallery.Core.Infrastructor.Repositories.Implementation
{
    public class CarRepository : BaseRepository<Car, int>, ICarRepository
    {
        public CarRepository(EFContext context) : base(context)
        {
        }
    }
}