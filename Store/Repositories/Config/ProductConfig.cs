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
            
            builder.HasData(
                 new Product()
                 {
                     ProductId = 1,
                     ProductName = "Computer",
                     Price = 30_000
                 },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Phone",
                    Price = 40_000
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "Mouse",
                    Price = 1_000
                }
            );
        }
    }
}