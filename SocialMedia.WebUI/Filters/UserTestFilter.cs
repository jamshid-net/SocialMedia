using Flurl.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.WebUI.Filters;

public class UserTestFilter :Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var res = context.Result;

        var resultContext = await next();

        var actionResult = resultContext.Result;

        var okResult = actionResult as OkObjectResult;

        var actualUser = okResult.Value as List<UserGetDto>;

        foreach (var item in actualUser)
        {
            item.FullName = item.FullName + " hello";
        }



    }
}
