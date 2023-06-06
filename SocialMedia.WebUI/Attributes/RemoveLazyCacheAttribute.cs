namespace SocialMedia.WebUI.Attributes;

public class RemoveLazyCacheAttribute : ActionFilterAttribute
{
    private static IAppCache? _cache;
    private static IConfiguration? _configuration;
    private static string? key;
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        _cache = context.HttpContext.RequestServices.GetRequiredService<IAppCache>();
        key = _configuration.GetValue<string>("LazyCache:Key");
        _cache.Remove(key);
        await next();

    }
}

