using AutoMapper;
using PurchaseService.DTOs.Buyer;
using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;

namespace PurchaseService.Profiles
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
