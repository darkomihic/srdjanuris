using System.ComponentModel.DataAnnotations;

namespace PurchaseService.DTOs.Buyer
{
    public class BuyerUpdateDTO
    {
        [Required(ErrorMessage = "Id je obavezan")]
        public Guid buyerId { get; set; }

        [Required(ErrorMessage = "Korisničko ime je obavezno")]
        public string username { get; set; }

        [Required(ErrorMessage = "Email je obavezan")]
        [EmailAddress(ErrorMessage = "Unesite validnu email adresu")]
        public string email { get; set; }
    }
}
