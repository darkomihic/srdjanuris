using AutoMapper;
using RatingService.DTOs.Buyer;
using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Profiles
{
    public class BuyerProfile : Profile
    {
        public BuyerProfile()
        {
            CreateMap<Buyer, BuyerDTO>().ReverseMap();
            CreateMap<Buyer, BuyerConfirmation>().ReverseMap();
            CreateMap<BuyerConfirmation, BuyerConfirmationDTO>().ReverseMap();
            CreateMap<Buyer, BuyerCreationDTO>().ReverseMap();
            CreateMap<Buyer, BuyerUpdateDTO>().ReverseMap();

        }
    }
}
