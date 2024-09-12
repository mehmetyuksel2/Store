using System.Runtime.CompilerServices;

namespace StoreApp.infrastructe.Extensions
{
    public static class HttpRequestExtension
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue 
                ? $"{request.Path}{request.QueryString}"
                :request.Path.ToString();//mevcuttaki url yi alır
        }
    }
}
