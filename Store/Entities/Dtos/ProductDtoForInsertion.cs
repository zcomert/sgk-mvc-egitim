namespace Entities.Dtos
{
    public record ProductDtoForInsertion
    {
        public int CategoryId { get; init; }
        public String ProductName { get; init; }
        public decimal Price { get; init; }
    }
}