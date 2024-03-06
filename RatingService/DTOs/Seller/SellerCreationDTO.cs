using System.ComponentModel.DataAnnotations;

namespace RatingService.DTOs.Seller
{
    public class SellerCreationDTO
    {
        [Required(ErrorMessage = "Username je obavezan")] public string username { get; set; }
        [Required(ErrorMessage = "Email je obavezan")] public string email { get; set; }
    }
}
