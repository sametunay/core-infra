using Microsoft.EntityFrameworkCore;
using CI.Core.Domain.Entities;

namespace CI.Core.Data.Contexts.EF
{
    public class EFContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(car =>
            {
                car.HasKey(c => c.Id);
                car
                    .HasOne(c => c.Brand)
                    .WithMany(b => b.Cars)
                    .HasForeignKey(c => c.BrandId);
                car
                    .HasOne(c => c.CarCategory)
                    .WithMany(c => c.Cars)
                    .HasForeignKey(c => c.CarCategoryId);
                car.OwnsOne(c => c.Audit);
                car.OwnsOne(c => c.PowerInfo, od => od.OwnsOne(pw => pw.Engine));

                car.HasQueryFilter(c => c.Audit.Status != Domain.Enums.StatusEnum.Deleted);
            });

            modelBuilder.Entity<CarCategory>(category =>
            {
                category.HasKey(c => c.Id);
                category
                    .HasMany(c => c.Cars)
                    .WithOne(c => c.CarCategory)
                    .HasForeignKey(c => c.CarCategoryId);
                category.OwnsOne(c => c.Audit);

                category.HasQueryFilter(c => c.Audit.Status != Domain.Enums.StatusEnum.Deleted);
            });

            modelBuilder.Entity<Brand>(brand =>
            {
                brand.HasKey(b => b.Id);
                brand
                    .HasMany(b => b.Cars)
                    .WithOne(c => c.Brand)
                    .HasForeignKey(c => c.BrandId);
                brand.OwnsOne(b => b.Audit);

                brand.HasQueryFilter(b => b.Audit.Status != Domain.Enums.StatusEnum.Deleted);
            });
        }

    }
}

