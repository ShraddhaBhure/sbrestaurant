using AutoMapper;
using sbrestaurant.services.CouponAPI.Models;
using sbrestaurant.services.CouponAPI.Models.Dto;

namespace sbrestaurant.services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
