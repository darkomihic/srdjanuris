namespace RatingService.DTOs.Purchase
{
    public class PurchaseConfirmationDTO
    {
        public Guid purchaseId { get; set; }
        public DateOnly date { get; set; }
        public int price { get; set; }
    }
}
