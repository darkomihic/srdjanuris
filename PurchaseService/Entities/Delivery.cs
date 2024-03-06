using System.ComponentModel.DataAnnotations;

namespace PurchaseService.Entities
{
    public class Delivery
    {
        [Key] public Guid deliveryId { get; set; }
        [Required] public int price { get; set; }

    }
}
