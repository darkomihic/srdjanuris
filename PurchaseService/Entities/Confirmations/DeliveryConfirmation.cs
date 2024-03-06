using System.ComponentModel.DataAnnotations;

namespace PurchaseService.Entities.Confirmations
{
    public class DeliveryConfirmation
    {
        [Key] public Guid deliveryId { get; set; }
        [Required] public int price { get; set; }
    }
}
