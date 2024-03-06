using System.ComponentModel.DataAnnotations;

namespace PurchaseService.DTOs.Delivery
{
    public class DeliveryCreationDTO
    {


        [Required(ErrorMessage = "Cijena je obavezna")]
        public int price { get; set; }
    }
}
