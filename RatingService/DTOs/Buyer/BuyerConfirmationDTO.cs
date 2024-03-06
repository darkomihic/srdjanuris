namespace RatingService.DTOs.Buyer
{
    public class BuyerConfirmationDTO
    {
        public Guid buyerId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
    }
}
