
using sbrestaurant.services.OrderAPI.Models.Dto;

namespace sbrestaurant.services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
