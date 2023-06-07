
namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]

public class UserController : ApiBaseController
{

   
    [RemoveLazyCache]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> CreateUser([FromForm] CreateUserCommand command)
        => Ok(await _mediatr.Send(command));

    [RemoveLazyCache]
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async ValueTask<IActionResult> DeleteUser([FromForm] DeleteUserCommand command)
                 => Ok(await _mediatr.Send(command));




    [RemoveLazyCache]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> UpdateUser([FromForm] UpdateUserCommand command)
        => Ok(await _mediatr.Send(command));



    [EnableRateLimiting("Api")]
    [AddLazyCache]
    [HttpGet("getall")]
    public async ValueTask<IActionResult> GetAllUser()
        => Ok(await _mediatr.Send(new GetAllUsersQuery()));

    [AddLazyCache]
    [HttpGet("getById")]
    public async ValueTask<IActionResult> GetByIdUser([FromQuery] GetByIdUserQuery command)
          => Ok(await _mediatr.Send(command));
    
       
    

}
