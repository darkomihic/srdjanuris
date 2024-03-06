using System.ComponentModel.DataAnnotations;

namespace PurchaseService.DTOs.Post
{
    public class PostCreationDTO
    {


        [Required(ErrorMessage = "Naslov je obavezan")]
        public string title { get; set; }

        [Required(ErrorMessage = "Datum je obavezan")]
        public DateOnly date { get; set; }

        [Required(ErrorMessage = "OwnerId je obavezan")]
        public Guid ownerId { get; set; }

        [Required(ErrorMessage = "Vlasničko korisničko ime je obavezno")]
        public string ownerUsername { get; set; }
    }
}
