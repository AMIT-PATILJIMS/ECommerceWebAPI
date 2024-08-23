using System.ComponentModel.DataAnnotations;

namespace ECommerceWebAPI.DTO
{
    //This class contains only the properties required for status update operations.
    public class OrderStatusDTO
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
