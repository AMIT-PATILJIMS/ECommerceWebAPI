using System.ComponentModel.DataAnnotations;

namespace ECommerceWebAPI.DTO
{
    //This class contains only the properties that are required to create a new order.
    public class OrderDTO
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public List<OrderItemDetailsDTO> Items { get; set; }
    }
}
