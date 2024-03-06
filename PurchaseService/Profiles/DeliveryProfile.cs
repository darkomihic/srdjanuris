using AutoMapper;
using PurchaseService.DTOs.Delivery;
using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;

namespace PurchaseService.Profiles
{
    public class DeliveryProfile : Profile
    {
        public DeliveryProfile()
        {
            CreateMap<Delivery, DeliveryDTO>().ReverseMap();
            CreateMap<Delivery, DeliveryConfirmation>().ReverseMap();
            CreateMap<DeliveryConfirmation, DeliveryConfirmationDTO>().ReverseMap();
            CreateMap<Delivery, DeliveryCreationDTO>().ReverseMap();
            CreateMap<Delivery, DeliveryUpdateDTO>().ReverseMap();
        }
    }
}
