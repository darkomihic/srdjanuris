using AutoMapper;
using RatingService.DTOs.Seller;
using RatingService.Entities;
using RatingService.Entities.Confirmations;

namespace RatingService.Profiles
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {
            CreateMap<Seller, SellerDTO>().ReverseMap();
            CreateMap<Seller, SellerConfirmation>().ReverseMap();
            CreateMap<SellerConfirmation, SellerConfirmationDTO>().ReverseMap();
            CreateMap<Seller, SellerCreationDTO>().ReverseMap();
            CreateMap<Seller, SellerUpdateDTO>().ReverseMap();
        }
    }
}
