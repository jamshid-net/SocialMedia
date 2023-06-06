namespace SocialMedia.WebUI.Attributes;
public class AddLazyCacheAttribute : ActionFilterAttribute
{
    private static IAppCache? _cache;
    private static IConfiguration? _configuration;
    private static string? key;
    private static TimeSpan duration;

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
         _cache = context.HttpContext.RequestServices.GetRequiredService<IAppCache>();
         _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

        if (context.HttpContext.Request.Path == "/api/User/getall")
        {
            key = _configuration.GetValue<string>("LazyCache:Key1");

        }
        if (context.HttpContext.Request.Path == "/api/Role/getall")
        {
            key = _configuration.GetValue<string>("LazyCache:Key2");

        }



        duration = TimeSpan.FromSeconds(_configuration.GetValue<double>("LazyCache:Duration"));
         var cachedResult =await _cache.GetOrAddAsync(key, ()=> next(),duration);

         if (cachedResult is not null)
              context.Result = cachedResult.Result;
        
        
    }

}
