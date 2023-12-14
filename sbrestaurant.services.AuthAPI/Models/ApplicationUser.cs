using Microsoft.AspNetCore.Identity;

namespace sbrestaurant.services.AuthAPI.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
		//    public string LastName { get; set; }
	}
}
