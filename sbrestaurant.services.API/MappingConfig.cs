using AutoMapper;
using sbrestaurant.services.API.Dto;
using sbrestaurant.services.API.Models;

namespace sbrestaurant.services.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
