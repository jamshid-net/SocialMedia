namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]

public class ApiBaseController : Controller
{
    protected IMediator _mediatr 
        => HttpContext.RequestServices.GetRequiredService<IMediator>();
    
}
