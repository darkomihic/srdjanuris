using System.ComponentModel.DataAnnotations;

namespace RatingService.DTOs.Purchase
{
    public class PurchaseDTO
    {
        public Guid purchaseId { get; set; }
        public DateOnly date { get; set; }
        public int price { get; set; }
    }
}
