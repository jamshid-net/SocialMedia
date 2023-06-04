

namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ApiBaseController
{
    [HttpPost("create")]
    public async ValueTask<IActionResult> CreateUser([FromForm]CreateUserCommand command)
    {
        var result =await _mediatr.Send(command);
        return Ok(result);
    }


}
