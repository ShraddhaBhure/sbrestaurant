using Newtonsoft.Json;
using sbrestaurant.Web.Models;
using sbrestaurant.Web.Service.IService;
using System;
using System.Net;                                  
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static sbrestaurant.Web.Utility.SD;

namespace sbrestaurant.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, TokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            using (HttpClient client = _httpClientFactory.CreateClient("RestaurantAPI"))
            {
                // HttpRequestMessage message = new HttpRequestMessage();
                //   message.Headers.Add("Content-Type", "application/json");
                //  message.RequestUri = new Uri(requestDto.Url);

             
                string fullUrl = requestDto.Url; // If the URL is already an absolute URL, you can use it as is.
                if (!Uri.IsWellFormedUriString(fullUrl, UriKind.Absolute))
                {
                    fullUrl = client.BaseAddress + fullUrl;
                }
                HttpRequestMessage message = new HttpRequestMessage
                {
                    RequestUri = new Uri(fullUrl)
                };

                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;
                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                try
                {
                    switch (apiResponse.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            return new ResponseDto { IsSuccess = false, Message = "Not Found" };
                        case HttpStatusCode.Forbidden:
                            return new ResponseDto { IsSuccess = false, Message = "Access Denied" };
                        case HttpStatusCode.Unauthorized:
                            return new ResponseDto { IsSuccess = false, Message = "Unauthorized" };
                        case HttpStatusCode.InternalServerError:
                            return new ResponseDto { IsSuccess = false, Message = "Internal Server Error" };
                        default:
                            var apiContent = await apiResponse.Content.ReadAsStringAsync();
                            var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent) as ResponseDto;
                            return apiResponseDto;
                    }
                }
                catch (Exception ex)
                {
                    return new ResponseDto
                    {
                        Message = ex.Message.ToString(),
                        IsSuccess = false
                    };
                }
            }
        }

       
    }
}
