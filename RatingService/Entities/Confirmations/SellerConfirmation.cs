using System.ComponentModel.DataAnnotations;

namespace RatingService.Entities.Confirmations
{
    public class SellerConfirmation
    {
        public Guid sellerId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
    }
}
