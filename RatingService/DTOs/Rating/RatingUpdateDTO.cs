using System.ComponentModel.DataAnnotations;

namespace RatingService.DTOs.Rating
{
    public class RatingUpdateDTO
    {
        [Required(ErrorMessage = "Id je obavezan")] public Guid ratingId { get; set; }
        [Required(ErrorMessage = "Date je obavezan")] public DateOnly date { get; set; }
        [Required(ErrorMessage = "Grade je obavezan")] public int grade { get; set; }
        public string comment { get; set; }
        public string title { get; set; }
        [Required(ErrorMessage = "BuyerID je obavezan")] public Guid buyerId { get; set; }
        [Required(ErrorMessage = "SellerID je obavezan")] public Guid sellerId { get; set; }
        [Required(ErrorMessage = "PurchaseID je obavezan")] public Guid purchaseId { get; set; }
    }
}
