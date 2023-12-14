using sbrestaurant.services.AuthAPI.Models;

namespace sbrestaurant.services.AuthAPI.Service.IService
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);

	}
}
