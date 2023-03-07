namespace Capstone1.Infrastructure
{
    public static class UrlExtensionsForCart
    {
        public static string PathAndQuery(this HttpRequest httpRequest)=>
            httpRequest.QueryString.HasValue ? 
            $"{httpRequest.Path}{httpRequest.Query}" : httpRequest.Path.ToString();
    }
}
