using System.ComponentModel.DataAnnotations;

namespace PurchaseService.DTOs.Delivery
{
    public class DeliveryUpdateDTO
    {
        [Required(ErrorMessage = "DeliveryId je obavezan")]
        public Guid deliveryId { get; set; }

        [Required(ErrorMessage = "Cijena je obavezna")]
        public int price { get; set; }
    }
}
