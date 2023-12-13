using sbrestaurant.services.RewardAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace sbrestaurant.services.RewardAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Rewards> Rewards { get; set; }

      
    }
}
