using sbrestaurant.services.EmailAPI.Message;
using sbrestaurant.services.EmailAPI.Models.Dto;

namespace sbrestaurant.services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
        Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RewardsMessage rewardsDto);
    }
}
