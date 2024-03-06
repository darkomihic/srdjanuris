using System.ComponentModel.DataAnnotations;

namespace PurchaseService.DTOs.Purchase
{
    public class PurchaseUpdateDTO
    {
        [Required(ErrorMessage = "PurchaseId je obavezan")]
        public Guid purchaseId { get; set; }

        [Required(ErrorMessage = "Datum je obavezan")]
        public DateOnly date { get; set; }

        [Required(ErrorMessage = "Cijena je obavezna")]
        public int price { get; set; }

        [Required(ErrorMessage = "DeliveryId je obavezan")]
        public Guid deliveryId { get; set; }

        [Required(ErrorMessage = "BuyerId je obavezan")]
        public Guid buyerId { get; set; }

        [Required(ErrorMessage = "PostId je obavezan")]
        public Guid postId { get; set; }
    }
}
