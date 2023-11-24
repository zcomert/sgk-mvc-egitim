using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.CategoryId);

        builder.Property(c => c.CategoryName).IsRequired();

        builder.HasData(
            new Category() { CategoryId = 1, CategoryName = "Bilgisayar" },
            new Category() { CategoryId = 2, CategoryName = "Elektronik" },
            new Category() { CategoryId = 3, CategoryName = "Telefonlar" },
            new Category() { CategoryId = 4, CategoryName = "Televizyonlar" }
        );
    }
}