using sbrestaurant.services.RewardAPI.Message;

namespace sbrestaurant.services.RewardAPI.Services
{
    public interface IRewardService
    {
        Task UpdateRewards(RewardsMessage rewardsMessage);
    }
}
