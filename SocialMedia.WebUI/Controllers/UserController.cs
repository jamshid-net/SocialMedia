
namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ApiBaseController
{
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> CreateUser([FromForm]CreateUserCommand command)
        => Ok(await _mediatr.Send(command));

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async ValueTask<IActionResult> DeleteUser([FromForm] DeleteUserCommand command)
        => Ok(await _mediatr.Send(command));


    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> UpdateUser([FromForm]UpdateUserCommand command)   
        => Ok(await _mediatr.Send(command));

    
    [HttpGet("getall")]
    public async ValueTask<IActionResult> GetAllUser()
        => Ok(await _mediatr.Send(new GetAllUsersQuery()));

    [HttpGet("getById")]
    public async ValueTask<IActionResult> GetByIdUser([FromForm]GetByIdUserQuery command)
        => Ok(await _mediatr.Send(command));    

}
