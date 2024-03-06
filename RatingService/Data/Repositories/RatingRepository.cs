using AutoMapper;
using RatingService.Data.Interface;
using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Data.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public RatingRepository(Context context, IMapper mapper)
        {
               this.context = context;
            this.mapper = mapper;   
        }

        public RatingConfirmation CreateRating(Rating rating)
        {
            var createdEntity = context.Rating.Add(rating);
            context.SaveChanges();
            return mapper.Map<RatingConfirmation>(createdEntity);
        }

        public Rating GetRatingById(Guid ratingId)
        {
            return context.Rating.FirstOrDefault(e => e.ratingId == ratingId);
        }
        public void DeleteRating(Guid ratingId)
        {
            var projekat = GetRatingById(ratingId);
            context.Remove(projekat);
        }

        public List<Rating> GetRatings()
        {
            return context.Rating.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Rating UpdateRating(Rating rating)
        {
            try
            {
                var existingRating = context.Rating.FirstOrDefault(e => e.ratingId == rating.ratingId);
                if (existingRating != null)
                {
                    existingRating.ratingId = rating.ratingId;
                    existingRating.title = rating.title;
                    existingRating.comment = rating.comment;
                    existingRating.date = rating.date;  
                    existingRating.grade = rating.grade;

                    context.SaveChanges();
                    return existingRating;
                }
                else
                {
                    throw new KeyNotFoundException($"Rating with ID {rating.ratingId} not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }




    }
}
