namespace ECommerceWebAPI.DTO
{
    //We will use this class as the return type of the action method that confirms the order.
    public class ConfirmOrderResponseDTO
    {
        public int OrderId { get; set; }
        public bool IsConfirmed { get; set; }
        public string Message { get; set; }
    }
}
