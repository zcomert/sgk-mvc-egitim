using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;


public record ProductDtoForUpdate : ProductDto
{
    public int ProductId { get; init; }
}