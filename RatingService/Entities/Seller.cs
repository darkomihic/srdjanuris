using System.ComponentModel.DataAnnotations;

namespace RatingService.Entities
{
    public class Seller
    {
        [Key] public Guid sellerId { get; set; }
        [Required] public string username {  get; set; }
        [Required] public string email { get; set; }
    }
}
