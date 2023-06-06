namespace SocialMedia.WebUI.Middlewares;
public class GetRequestContentMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMediator _mediatr;

    public GetRequestContentMiddleware(RequestDelegate next, IMediator mediatr)
    {
        _next = next;
        _mediatr = mediatr;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        if(httpContext.Request.Path == "/api/Post/create")
        {
            var createdPost =await httpContext.Request.ReadFormAsync();
            CreatePostCommand createPostCommand = new()
            {
                Title = createdPost["Title"],
                Content = createdPost["Content"]

            };
          
            await _mediatr.Publish(new PostNotification { CreatePostCommand =createPostCommand});


        }
        await _next(httpContext);
    }
}

public static class GetRequestContentMiddlewareExtensions
{
    public static IApplicationBuilder UseGetRequestContentMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GetRequestContentMiddleware>();
    }
}
