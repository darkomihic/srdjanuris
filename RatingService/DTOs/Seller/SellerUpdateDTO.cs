using System.ComponentModel.DataAnnotations;

namespace RatingService.DTOs.Seller
{
    public class SellerUpdateDTO
    {
        [Required(ErrorMessage = "BuyerId je obavezan")] public Guid sellerId { get; set; }
        [Required(ErrorMessage = "Username je obavezan")] public string username { get; set; }
        [Required(ErrorMessage = "Email je obavezan")] public string email { get; set; }
    }
}
