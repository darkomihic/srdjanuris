using System.ComponentModel.DataAnnotations;

namespace PurchaseService.Entities
{
    public class Buyer
    {
        [Key] public Guid buyerId { get; set; }
        [Required] public string username { get; set; }
        [Required] public string email { get; set; }
    }
}
