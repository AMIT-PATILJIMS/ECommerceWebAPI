using System.ComponentModel.DataAnnotations;

namespace ECommerceWebAPI.DTO
{
    public class OrderItemDetailsDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
