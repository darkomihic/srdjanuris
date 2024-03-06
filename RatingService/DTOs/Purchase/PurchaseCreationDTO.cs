using System.ComponentModel.DataAnnotations;

namespace RatingService.DTOs.Purchase
{
    public class PurchaseCreationDTO
    {
        [Required(ErrorMessage = "Date je obavezan")] public DateOnly date { get; set; }
        [Required(ErrorMessage = "Price je obavezan")] public int price { get; set; }
    }
}
