namespace LeParfum.Data.Entities
{    
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid Brand { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public Guid Gender { get; set; } 
        public ProductStatus Status { get; set; }
    }
}