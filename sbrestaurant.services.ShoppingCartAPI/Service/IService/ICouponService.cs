using sbrestaurant.services.ShoppingCartAPI.Models.Dto;

namespace sbrestaurant.services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
