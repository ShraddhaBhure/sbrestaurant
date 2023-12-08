using static sbrestaurant.Web.Utility.SD;

namespace sbrestaurant.Web.Models
{
    public class RequestDto
    {
        public  ApiType  ApiType { get; set; } = ApiType.GET;
        public string Url  { get; set; } 
        public object Data { get; set; } 
        public string AccesssToken { get; set; }
        public ContentType ContentType { get; set; } = ContentType.Json;
    }
}
