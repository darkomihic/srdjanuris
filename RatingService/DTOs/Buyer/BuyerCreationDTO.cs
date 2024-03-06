using System.ComponentModel.DataAnnotations;

namespace RatingService.DTOs.Buyer
{
    public class BuyerCreationDTO
    {
        [Required(ErrorMessage = "Username je obavezan")] public string username { get; set; }
        [Required(ErrorMessage = "Email je obavezan")] public string email { get; set; }
    }
}
