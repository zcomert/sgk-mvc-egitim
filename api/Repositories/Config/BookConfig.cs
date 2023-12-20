using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        // Fluent API
        builder.HasKey(b => b.Id); // Id - BookId
        builder.Property(b => b.Title).IsRequired();


        builder.HasData(
            new Book() { Id = 1, Title = "Mesnevi", Price = 300 },
            new Book() { Id = 2, Title = "Devlet", Price = 250 },
            new Book() { Id = 3, Title = "Sefiller", Price = 350 }
        );
    }
}