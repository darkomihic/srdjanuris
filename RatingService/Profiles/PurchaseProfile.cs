using AutoMapper;
using RatingService.DTOs.Purchase;
using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Profiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<Purchase, PurchaseDTO>().ReverseMap();
            CreateMap<Purchase, PurchaseConfirmation>().ReverseMap();
            CreateMap<PurchaseConfirmation, PurchaseConfirmationDTO>().ReverseMap();    
            CreateMap<Purchase, PurchaseCreationDTO>().ReverseMap();
            CreateMap<Purchase, PurchaseUpdateDTO>().ReverseMap();
        }
    }
}
