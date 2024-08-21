namespace ECommerceWebAPI.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }
    }
}
