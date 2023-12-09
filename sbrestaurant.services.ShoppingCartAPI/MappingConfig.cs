using AutoMapper;
using sbrestaurant.services.ShoppingCartAPI.Models.Dto;
using sbrestaurant.services.ShoppingCartAPI.Models;

namespace sbrestaurant.services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
