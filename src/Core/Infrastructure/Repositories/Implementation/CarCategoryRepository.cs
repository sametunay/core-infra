using CI.Core.Data.Contexts.EF;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructure.Repositories.Interfaces;

namespace CI.Core.Infrastructure.Repositories.Implementation
{
    public class CarCategoryRepository : BaseRepository<CarCategory, int>, ICarCategoryRepository
    {
        public CarCategoryRepository(EFContext context) : base(context)
        {
        }
    }
}