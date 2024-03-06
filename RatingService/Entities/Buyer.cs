using System.ComponentModel.DataAnnotations;

namespace RatingService.Entities
{
    public class Buyer
    {
        [Key] public Guid buyerId { get; set; }
        [Required] public string username { get; set; }
        [Required] public string email { get; set;}
    }
}
