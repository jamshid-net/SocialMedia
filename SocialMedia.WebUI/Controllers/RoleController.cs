

namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RoleController : ApiBaseController
{
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> CreateRole([FromForm] CreateRoleCommand command)
         => Ok(await _mediatr.Send(command));

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async ValueTask<IActionResult> DeleteRole([FromForm] DeleteRoleCommand command)
        => Ok(await _mediatr.Send(command));


    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> UpdateRole([FromForm] UpdateRoleCommand command)
        => Ok(await _mediatr.Send(command));


    [HttpGet("getall")]
    public async ValueTask<IActionResult> GetAllRole()
        => Ok(await _mediatr.Send(new GetAllRoleQuery()));

    [HttpGet("getById")]
    public async ValueTask<IActionResult> GetByIdRole([FromQuery] GetByIdRoleQuery command)
        => Ok(await _mediatr.Send(command));
}
