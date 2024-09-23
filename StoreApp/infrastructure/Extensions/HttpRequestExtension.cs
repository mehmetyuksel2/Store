using System.Runtime.CompilerServices;

namespace StoreApp.infrastructure.Extensions
{
    public static class HttpRequestExtension
    {
        public static string PathAndQuery(this HttpRequest request)
        {//mevcuttaki url yi alır
            return request.QueryString.HasValue 
                ? $"{request.Path}{request.QueryString}"
                :request.Path.ToString();
        }
    }
}
