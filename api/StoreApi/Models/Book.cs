namespace StoreApi.Models;

public class Book
{
    public int Id { get; set; }
    public String? Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
}