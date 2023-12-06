using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; } // Navigation property
        public String ProductName { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public String? ImageUrl { get; set; } = "/images/default.jpg";
        public DateTime? AtCreatedDate { get; set; }

        public Product()
        {
            AtCreatedDate = DateTime.Now.AddMinutes(1);
        }
    }
}