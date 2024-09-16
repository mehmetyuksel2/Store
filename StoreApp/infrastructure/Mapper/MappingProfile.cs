using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion,Product>();
            //ProductDtoForInsertion nesnesi product nesnesine dönüştürülmekte
            CreateMap<ProductDtoForUpdate,Product>().ReverseMap();
            //ReverseMap() metodu çift yönlü dönüştürme yapabilir
           
        }
    }
}