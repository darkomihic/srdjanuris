using System.ComponentModel.DataAnnotations;

namespace RatingService.Entities
{
    public class Purchase
    {
        [Key] public Guid purchaseId { get; set; }
        [Required] public DateOnly date {  get; set; }
        [Required] public int price { get; set; }

    }
}
