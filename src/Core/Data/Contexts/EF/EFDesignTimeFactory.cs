using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyGallery.Core.Data.Contexts.EF
{
    public class EFDesignTimeFactory : IDesignTimeDbContextFactory<EFContext>
    {
        public EFContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<EFContext>();
            optionBuilder.UseNpgsql("Host=localhost; Database=mygallery; Port=5432; User Id=postgres; Password=default;");

            return new EFContext(optionBuilder.Options);
        }
    }
}