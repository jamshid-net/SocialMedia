

namespace SocialMedia.WebUI.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class EtagMidlleware
{
    private readonly RequestDelegate _next;


    public EtagMidlleware(RequestDelegate next)
        => (_next) = (next);

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Path == "/api/Comment/getall")
        {
            var response = httpContext.Response;
            var orginalStream = response.Body;
            using var ms = new MemoryStream();
            response.Body = ms;

            await _next(httpContext);
            if (IsEtagSupported(response))
            {
                string checksum = CalculateChecksum(ms);

                if (httpContext.Request.Headers.TryGetValue(HeaderNames.IfMatch, out var etagVal) && checksum == etagVal)
                {
                    response.StatusCode = StatusCodes.Status304NotModified;
                    return;
                }
                response.Headers[HeaderNames.IfMatch] = checksum;

            }
            ms.Position = 0;
            await ms.CopyToAsync(orginalStream);

        }
        else await _next(httpContext);

    }
    private static bool IsEtagSupported(HttpResponse response)
    {
        if (response.StatusCode != StatusCodes.Status200OK)
            return false;

        // The 20kb length limit is not based in science. Feel free to change
        if (response.Body.Length > 20 * 1024)
            return false;

        if (response.Headers.ContainsKey(HeaderNames.ETag))
            return false;

        return true;
    }
    private static string CalculateChecksum(MemoryStream ms)
    {
        string checksum = "";

        using (var algo = SHA1.Create())
        {
            ms.Position = 0;
            byte[] bytes = algo.ComputeHash(ms);
            checksum = $"\"{WebEncoders.Base64UrlEncode(bytes)}\"";
        }

        return checksum;
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class EtagMidllewareExtensions
{
    public static IApplicationBuilder UseEtagMidlleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<EtagMidlleware>();
    }
}
