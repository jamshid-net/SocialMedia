namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostController : ApiBaseController
{   
    [RemoveLazyCache]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> CreatePost([FromForm] CreatePostCommand command)
       => Ok(await _mediatr.Send(command));
    
    [RemoveLazyCache]
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async ValueTask<IActionResult> DeletePost([FromForm] DeletePostCommand command)
        => Ok(await _mediatr.Send(command));

    
    [RemoveLazyCache]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> UpdatePost([FromForm] UpdatePostCommand command)
        => Ok(await _mediatr.Send(command));

   // [EnableRateLimiting("Api")]
    [AddLazyCache]
    [HttpGet("getall")]
    public async ValueTask<IActionResult> GetAllPost()
        => Ok(await _mediatr.Send(new GetAllPostQuery()));

    [HttpGet("getById")]
    public async ValueTask<IActionResult> GetByIdPost([FromQuery] GetByIdPostQuery command)
        => Ok(await _mediatr.Send(command));
}
