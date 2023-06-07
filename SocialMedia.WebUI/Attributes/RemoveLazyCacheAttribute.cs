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



        //if (context.HttpContext.Request.Path ==  "/api/User/create")
        //    key = _configuration.GetValue<string>("LazyCache:UserKey");

        //if (context.HttpContext.Request.Path == "/api/Login/getall")
        //    key = _configuration.GetValue<string>("LazyCache:RoleKey");

        //if (context.HttpContext.Request.Path == "/api/Comment/create")
        //    key = _configuration.GetValue<string>("LazyCache:CommentKey");

        //if (context.HttpContext.Request.Path == "/api/Post/getall")
        //    key = _configuration.GetValue<string>("LazyCache:PostKey");

        //if (context.HttpContext.Request.Path == "/api/Permission/getall")
        //    key = _configuration.GetValue<string>("LazyCache:PermissionKey");

        
        //_cache.Remove(key);
        await next();

    }
}

