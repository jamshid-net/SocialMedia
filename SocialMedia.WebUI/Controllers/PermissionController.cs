namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PermissionController : ApiBaseController
{
    [RemoveLazyCache]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> CreatePermission([FromForm] CreatePermissionCommand command)
         => Ok(await _mediatr.Send(command));
    [RemoveLazyCache]
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async ValueTask<IActionResult> DeletePermission([FromForm] DeletePermissionCommand command)
        => Ok(await _mediatr.Send(command));

    [RemoveLazyCache]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> UpdatePermission([FromForm] UpdatePermissionCommand command)
        => Ok(await _mediatr.Send(command));

    [AddLazyCache]
    [HttpGet("getall")]
    public async ValueTask<IActionResult> GetAllPermission()
        => Ok(await _mediatr.Send(new GetAllPermissionQuery()));

    [HttpGet("getById")]
    public async ValueTask<IActionResult> GetByIdPermission([FromQuery] GetByIdPermissionQuery command)
        => Ok(await _mediatr.Send(command));


}
