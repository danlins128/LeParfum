using LeParfum.Domain.Enums;

namespace LeParfum.Domain.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid BrandId { get; set; }
        public BrandEntity Brand { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid GenderId { get; set; }
        public GenderEntity Gender { get; set; } = null!;
        public bool IsHighlighted { get; set; }
        public ProductStatus Status { get; set; }
    }
}