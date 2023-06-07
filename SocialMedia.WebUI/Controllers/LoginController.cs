

namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ApiBaseController
{
    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([FromForm] UserLoginCommand command)
          => Ok(await _mediatr.Send(command));


    [HttpPost("refresehtoken")]
    public async ValueTask<IActionResult> RefreshToken([FromForm] UserGetNewTokenCommand command)
        => Ok(await _mediatr.Send(command));
}
