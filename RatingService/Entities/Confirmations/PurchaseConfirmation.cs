using System.ComponentModel.DataAnnotations;

namespace RatingService.Entities.Confirmations
{
    public class PurchaseConfirmation
    {
        public Guid purchaseId { get; set; }
        public DateOnly date { get; set; }
        public int price { get; set; }
    }
}
