namespace LeParfum.Data.Entities
{
    public class StockEntity
    {
        public Guid Id { get; set; }
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}