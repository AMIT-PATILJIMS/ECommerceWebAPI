namespace ECommerceWebAPI.DTO
{
    //We will use this class as the return type of the action method that updates the order status.
    public class OrderStatusResponseDTO
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public bool IsUpdated { get; set; }
        public string Message { get; set; }
    }
}
