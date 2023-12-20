namespace SportsStore.Infrastructure;

// Extension method class for simplifying the retrieval of the combined path and query string from an HttpRequest.
public static class UrlExtensions
{
    // Extension method to get the combined path and query string from an HttpRequest.
    public static string PathAndQuery(this HttpRequest request) =>
        request.QueryString.HasValue
            ? $"{request.Path}{request.QueryString}"
            : request.Path.ToString();
}