using PurchaseService.DTOs.Post;
using PurchaseService.Entities.Confirmations;
using PurchaseService.Entities;
using AutoMapper;

namespace PurchaseService.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Post, PostConfirmation>().ReverseMap();
            CreateMap<PostConfirmation, PostConfirmationDTO>().ReverseMap();
            CreateMap<Post, PostCreationDTO>().ReverseMap();
            CreateMap<Post, PostUpdateDTO>().ReverseMap();
        }
    }
}
