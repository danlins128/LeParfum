namespace LeParfum.Application.DTOs
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public decimal Price { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public Guid GenderId { get; set; }
        public string GenderName { get; set; } = null!;
        public bool IsHighLighted { get; set; }
    }
}