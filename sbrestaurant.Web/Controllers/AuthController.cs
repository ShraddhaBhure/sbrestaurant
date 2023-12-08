using sbrestaurant.Web.Models;
using sbrestaurant.Web.Service.IService;
using sbrestaurant.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace sbrestaurant.Web.Controllers
{
    public class AuthController : Controller
    {
            private readonly IAuthService _authService;
            private readonly ITokenProvider _tokenProvider;

            public AuthController(IAuthService authService, ITokenProvider tokenProvider)
            {
                _authService = authService;
                _tokenProvider = tokenProvider;
            }

            [HttpGet]
            public IActionResult Login()
            {
                LoginRequestDto loginRequestDto = new();
                return View(loginRequestDto);
            }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDto = await _authService.LoginAsync(obj);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto =
                    JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                await SignInUser(loginResponseDto);
                // _tokenProvider.SetToken(loginResponseDto.Token);
                
                TempData["UserName"] = $"Welcome back, {obj.UserName}!";
                TempData["success"] = $"Welcome back, { obj.UserName /*,User.Identity.Name*/}!";
                return RedirectToAction("Index", "Home");
            }

            else
            {
                TempData["error"] = responseDto.Message;
                return View(obj);
            }
        }




        [HttpGet]
            public IActionResult Register()
            {
                var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value=SD.RoleCustomer},
            };

                ViewBag.RoleList = roleList;
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Register(RegistrationRequestDto obj)
            {
                ResponseDto result = await _authService.RegisterAsync(obj);
                ResponseDto assingRole;

                if (result != null && result.IsSuccess)
                {
                    if (string.IsNullOrEmpty(obj.Role))
                    {
                        obj.Role = SD.RoleCustomer;
                    }
                    assingRole = await _authService.AssignRoleAsync(obj);
                    if (assingRole != null && assingRole.IsSuccess)
                    {
                        TempData["success"] = "Registration Successful";
                        return RedirectToAction(nameof(Login));
                    }
                }
                else
                {
                    TempData["error"] = result.Message;
                }

                var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value=SD.RoleCustomer},
            };

                ViewBag.RoleList = roleList;
                return View(obj);
            }


            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync();
                _tokenProvider.ClearToken();
                return RedirectToAction("Index", "Home");
            }


        private async Task SignInUser(LoginResponseDto model)
         {
            if (model != null && !string.IsNullOrEmpty(model.Token))
            {                                                                                                                                           
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(model.Token);

                if (jwt != null && jwt.Claims != null && jwt.Claims.Any())
                {                                                                                                                           
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                    var emailClaim = jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email);
                    if (emailClaim != null && !string.IsNullOrEmpty(emailClaim.Value))
                    {
                        identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, emailClaim.Value));
                    }

                    var subClaim = jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub);
                    if (subClaim != null && !string.IsNullOrEmpty(subClaim.Value))
                    {
                        identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, subClaim.Value));
                    }

                    var nameClaim = jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name);
                    if (nameClaim != null && !string.IsNullOrEmpty(nameClaim.Value))
                    {
                        identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name, nameClaim.Value));
                    }

                    var roleClaim = jwt.Claims.FirstOrDefault(u => u.Type == "role");
                    if (roleClaim != null && !string.IsNullOrEmpty(roleClaim.Value))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, roleClaim.Value));
                    }

                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                }
                else
                {
                    TempData["error"] = "JWT claims not present or empty";
                }
            }
            else
            {
                TempData["error"] = "Model or Token is null or empty";
            }
        }

        //private async Task SignInUser(LoginResponseDto model)
        //{
        //    if (model != null && !string.IsNullOrEmpty(model.Token))
        //    {
        //        var handler = new JwtSecurityTokenHandler();
        //        var jwt = handler.ReadJwtToken(model.Token);

        //        if (jwt != null && jwt.Claims != null && jwt.Claims.Any())
        //        {
        //            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        //            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
        //                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email)?.Value));
        //            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
        //                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub)?.Value));
        //            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
        //                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name)?.Value));

        //            identity.AddClaim(new Claim(ClaimTypes.Name,
        //                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email)?.Value));

        //            identity.AddClaim(new Claim(ClaimTypes.Role,
        //                jwt.Claims.FirstOrDefault(u => u.Type == "role")?.Value));

        //            var principal = new ClaimsPrincipal(identity);
        //            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        //        }
        //        else
        //        {
        //            TempData["error"] = "Action not Successful";
        //            // Handle the case where jwt or jwt.Claims is null or empty
        //            // You may want to log or throw an exception, depending on your requirements
        //        }
        //    }
        //    else
        //    {
        //        TempData["error"] = "Action not Successful";
        //        // Handle the case where model or model.Token is null or empty
        //    }
        //}


        //private async Task SignInUser(LoginResponseDto model)
        //{
        //    var handler = new JwtSecurityTokenHandler();

        //    var jwt = handler.ReadJwtToken(model.Token);

        //    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        //    identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
        //        jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
        //    identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
        //        jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
        //    identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
        //        jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));


        //    identity.AddClaim(new Claim(ClaimTypes.Name,
        //        jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
        //    identity.AddClaim(new Claim(ClaimTypes.Role,
        //        jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));



        //    var principal = new ClaimsPrincipal(identity);
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        //}

    }
}
