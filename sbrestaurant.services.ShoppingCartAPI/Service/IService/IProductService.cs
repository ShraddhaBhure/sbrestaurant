using sbrestaurant.services.ShoppingCartAPI.Models.Dto;

namespace sbrestaurant.services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
