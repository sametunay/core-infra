using CI.Core.Data.Contexts.EF;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructor.Repositories.Interfaces;

namespace CI.Core.Infrastructor.Repositories.Implementation
{
    public class CarRepository : BaseRepository<Car, int>, ICarRepository
    {
        public CarRepository(EFContext context) : base(context)
        {
        }
    }
}