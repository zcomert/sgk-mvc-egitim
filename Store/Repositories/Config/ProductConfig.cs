using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.ProductName)
            .IsRequired();

            builder.Property(p => p.AtCreatedDate)
                .HasDefaultValue(DateTime.Now.AddMinutes(1));

            builder.Property(p => p.ImageUrl)
                .HasDefaultValue("/images/default.jpg");

            builder.HasData(
                 new Product()
                 {
                     ProductId = 1,
                     CategoryId = 1,
                     ProductName = "Computer",
                     Price = 30_000
                 },
                new Product()
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "Phone",
                    Price = 40_000
                },
                new Product()
                {
                    ProductId = 3,
                    CategoryId = 1,
                    ProductName = "Mouse",
                    Price = 1_000
                }
            );
        }
    }
}