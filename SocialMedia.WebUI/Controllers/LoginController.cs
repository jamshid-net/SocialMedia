using SocialMedia.Application.Users.Login;

namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ApiBaseController
{
    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([FromForm] UserLoginCommand userLoginCommand)
          => Ok(await _mediatr.Send(userLoginCommand));
}
