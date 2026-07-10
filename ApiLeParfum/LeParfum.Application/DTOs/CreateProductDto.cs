namespace LeParfum.Application.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid GenderId { get; set; }
        public bool IsHighLighted { get; set; }
    }
}