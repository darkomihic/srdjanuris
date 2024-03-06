using System.ComponentModel.DataAnnotations;

namespace PurchaseService.Entities.Confirmations
{
    public class PurchaseConfirmation
    {
        public Guid purchaseId { get; set; }
        public DateOnly date { get; set; }
        public int price { get; set; }
        public Guid deliveryId { get; set; }
        public Guid buyerId { get; set; }
        public Guid postId { get; set; }
    }
}
