using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StoreApp.infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

            // UserDtoForCreation -> IdentityUser haritalaması
            CreateMap<UserDtoForCreation, IdentityUser>();
            //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            //.ForMember(dest => dest.PasswordHash, opt => opt.Ignore()).ReverseMap(); // PasswordHash'ı ignore et, manuel olarak ayarlanacak

            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
        }
    }

}