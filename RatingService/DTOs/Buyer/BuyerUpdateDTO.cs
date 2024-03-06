using System.ComponentModel.DataAnnotations;

namespace RatingService.DTOs.Buyer
{
    public class BuyerUpdateDTO
    {
        [Required(ErrorMessage = "BuyerId je obavezan")] public Guid buyerId { get; set; }
        [Required(ErrorMessage = "Username je obavezan")] public string username { get; set; }
        [Required(ErrorMessage = "Email je obavezan")] public string email { get; set; }
    }
}
