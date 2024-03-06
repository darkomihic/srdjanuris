using System.ComponentModel.DataAnnotations;

namespace PurchaseService.DTOs.Buyer
{
    public class BuyerCreationDTO
    {


        [Required(ErrorMessage = "Korisničko ime je obavezno")]
        public string username { get; set; }

        [Required(ErrorMessage = "Email je obavezan")]
        [EmailAddress(ErrorMessage = "Unesite validnu email adresu")]
        public string email { get; set; }
    }
}
