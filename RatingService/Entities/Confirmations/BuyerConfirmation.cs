using System.ComponentModel.DataAnnotations;

namespace RatingService.Entities.Confirmations
{
    public class BuyerConfirmation
    {
        public Guid buyerId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
    }
}
