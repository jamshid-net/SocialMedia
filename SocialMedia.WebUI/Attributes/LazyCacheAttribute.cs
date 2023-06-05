using Microsoft.AspNetCore.Http.HttpResults;

namespace SocialMedia.WebUI.Attributes;

public class LazyCacheAttribute : ActionFilterAttribute
{
    private static IAppCache? _cache;
    private readonly string _cacheKey;
    private readonly TimeSpan _cacheDuration;

    public LazyCacheAttribute(string cacheKey, int cacheDurationInSeconds)
    {
        
        _cacheKey = cacheKey;
        _cacheDuration = TimeSpan.FromSeconds(cacheDurationInSeconds);
    }
   

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {

        _cache = context.HttpContext.RequestServices.GetRequiredService<IAppCache>();   
        var cachedResult =await _cache.GetOrAddAsync(_cacheKey,()=> next(),_cacheDuration);

        if (cachedResult is not null)
        {
            context.Result = cachedResult.Result;
        }
       

    }

}
public class RemoveCacheAttribute : ActionFilterAttribute
{
    private static IAppCache? _cache;
    private static string? _key;
    public RemoveCacheAttribute(string key)
           =>_key = key;   
    
    
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _cache = context.HttpContext.RequestServices.GetRequiredService<IAppCache>();
        _cache.Remove(_key);
        await next();

    }
}
