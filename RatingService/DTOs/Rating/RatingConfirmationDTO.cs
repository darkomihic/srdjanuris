namespace RatingService.DTOs.Rating
{
    public class RatingConfirmationDTO
    {
        public Guid ratingId { get; set; }
        public DateOnly date { get; set; }
        public int grade { get; set; }
        public string comment { get; set; }
        public string title { get; set; }
    }
}
