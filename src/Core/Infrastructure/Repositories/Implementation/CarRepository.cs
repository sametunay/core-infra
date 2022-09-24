using CI.Core.Data.Contexts.EF;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructure.Repositories.Interfaces;

namespace CI.Core.Infrastructure.Repositories.Implementation
{
    public class CarRepository : BaseRepository<Car, int>, ICarRepository
    {
        public CarRepository(EFContext context) : base(context)
        {
        }
    }
}