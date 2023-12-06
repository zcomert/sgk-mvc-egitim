using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record ProductDto
{
    public int CategoryId { get; init; }
    [Required(ErrorMessage = "Ürün adı zorunludur.")]
    public String ProductName { get; init; }
    
    [Range(100, 100_000, ErrorMessage = "Ürün fiyatı 100 ve 100.000 arasında olmalı.")]
    public decimal Price { get; init; }
}