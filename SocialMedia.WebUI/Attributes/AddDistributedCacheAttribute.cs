namespace SocialMedia.WebUI.Attributes;

public class AddDistributedCacheAttribute : IAsyncActionFilter
{
    private static IDistributedCache? _distributedcache;
    public const string _cacheKey = "usergetall2";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {

		try
		{
            _distributedcache = context.HttpContext.RequestServices.GetRequiredService<IDistributedCache>();
            await _distributedcache.GetStringAsync(_cacheKey);
            await next();

		}
		finally 
        {
            await _distributedcache.SetStringAsync(_cacheKey, JsonConvert.SerializeObject(context.HttpContext.Response));
            
        }
    }
}
