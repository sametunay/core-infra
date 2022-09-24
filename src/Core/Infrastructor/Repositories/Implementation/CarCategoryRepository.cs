using CI.Core.Data.Contexts.EF;
using CI.Core.Domain.Entities;
using CI.Core.Infrastructor.Repositories.Interfaces;

namespace CI.Core.Infrastructor.Repositories.Implementation
{
    public class CarCategoryRepository : BaseRepository<CarCategory, int>, ICarCategoryRepository
    {
        public CarCategoryRepository(EFContext context) : base(context)
        {
        }
    }
}