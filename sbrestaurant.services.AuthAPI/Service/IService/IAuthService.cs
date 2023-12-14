using sbrestaurant.services.AuthAPI.Models.Dto;

namespace sbrestaurant.services.AuthAPI.Service.IService
{
	public interface IAuthService
	{
		Task<String> Register(RegistrationRequestDto registerationRequestDto);

		Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
		Task<bool> AssignRole(string email, string roleName);
	}
}
