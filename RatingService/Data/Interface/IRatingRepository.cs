using RatingService.Entities.Confirmations;
using RatingService.Entities;

namespace RatingService.Data.Interface
{
    public interface IRatingRepository
    {
        RatingConfirmation CreateRating(Rating rating);
        Rating GetRatingById(Guid ratingId);
        void DeleteRating(Guid ratingId);
        List<Rating> GetRatings();
        bool SaveChanges();
        Rating UpdateRating(Rating rating);
    }
}
