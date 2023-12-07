namespace Entities.Models;

public class Cart
{
    public List<CartItem> Lines { get; set; }
    public Cart()
    {
        Lines = new List<CartItem>();
    }

    public virtual void AddItem(Product product, int quantity=1)
    {
        CartItem? line = Lines
        .FirstOrDefault(cl => 
            cl.Product.Equals(product.ProductId));

        if(line is null)
        {
            Lines.Add(new CartItem()
            {
                Product = product,
                Quantity = quantity
            });
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public void RemoveLine(Product product)
    {
        Lines.RemoveAll(p => 
            p.Product.ProductId.Equals(product.ProductId));
    }

    public void Clear() => Lines.Clear();

    public decimal CalculateTotalValue()
    {
        // decimal total = 0;
        // foreach (var line in Lines)
        // {
        //     total += line.Product.Price * line.Quantity;
        // }
        // return total;

        return Lines.Sum(l =>
            l.Product.Price * l.Quantity);
    }
}