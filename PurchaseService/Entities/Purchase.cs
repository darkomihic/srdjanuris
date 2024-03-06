using System.ComponentModel.DataAnnotations;

namespace PurchaseService.Entities
{
    public class Purchase
    {
        [Key] public Guid purchaseId { get; set; }
        [Required] public DateOnly date { get; set; }
        [Required] public int price { get; set; }
        [Required] public Guid deliveryId { get; set; }
        [Required] public Guid buyerId { get; set; }
        [Required] public Guid postId { get; set; }


    }
}
