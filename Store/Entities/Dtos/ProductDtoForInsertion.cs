using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDtoForInsertion : ProductDto
    {
        public String? ImageUrl { get; set; }
    }
}