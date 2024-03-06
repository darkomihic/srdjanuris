namespace PurchaseService.DTOs.Purchase
{
    public class PurchaseDTO
    {
        public Guid purchaseId { get; set; }
        public DateOnly date { get; set; }
        public int price { get; set; }
        public Guid deliveryId { get; set; }
        public Guid buyerId { get; set; }
        public Guid postId { get; set; }
    }
}
