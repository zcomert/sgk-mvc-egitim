namespace Entities.Models;

public class CartItem
{
    public int CartItemId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    // public decimal TotalLine => Product.Price * Quantity;
}