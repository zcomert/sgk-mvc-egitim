using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Book
    {
        public int Id { get; set; }

        [MinLength(4, ErrorMessage = "Title en az 4 karakterden oluşmalı.")]
        [MaxLength(30, ErrorMessage = "Title maksimum 12 karakter olmalı.")]
        public String? Title { get; set; } = string.Empty;

        [Range(10, 900, ErrorMessage = "Price 10 - 900 arasında olmalı")]
        public decimal Price { get; set; }

        public static Book CreateBook () => new Book ();

        public Book SetTitle(string title)
        {
            Title = title;
            return this;
        }

        public Book SetPrice(decimal price)
        {
            Price = price;
            return this;
        }
    }
}
