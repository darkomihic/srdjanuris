using AutoMapper;
using PurchaseService.DTOs.Purchase;
using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;

namespace PurchaseService.Profiles
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
