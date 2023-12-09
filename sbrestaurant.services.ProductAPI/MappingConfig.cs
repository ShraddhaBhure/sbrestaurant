using AutoMapper;
using sbrestaurant.services.ProductAPI.Models;
using sbrestaurant.services.ProductAPI.Models.Dto;

namespace sbrestaurant.services.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
