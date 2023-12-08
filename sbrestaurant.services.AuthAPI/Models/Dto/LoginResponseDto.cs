using sbrestaurant.services.API.Dto;

namespace sbrestaurant.services.AuthAPI.Models.Dto
{
	public class LoginResponseDto
	{
		public UserDto User { get; set; }
		public string Token { get; set; }
	}
}
