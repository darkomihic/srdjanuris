using System.ComponentModel.DataAnnotations;

namespace RatingService.DTOs.Seller
{
    public class SellerDTO
    {
        public Guid sellerId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
    }
}
