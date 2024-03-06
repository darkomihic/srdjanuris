using AutoMapper;
using RatingService.DTOs.Rating;
using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Profiles
{
    public class RatingProfile : Profile
    {

        public RatingProfile()
        {
            CreateMap<Rating, RatingDTO>().ReverseMap();
            CreateMap<Rating, RatingConfirmation>().ReverseMap();
            CreateMap<RatingConfirmation, RatingConfirmationDTO>().ReverseMap();
            CreateMap<Rating, RatingCreationDTO>().ReverseMap();    
            CreateMap<Rating, RatingUpdateDTO>().ReverseMap();  

        }
        
    }
}
