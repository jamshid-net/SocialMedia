

namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommentController : ApiBaseController
{

    [HttpPost("reply")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> ReplyComment([FromForm] ReplyMessageCommentCommand command)
         => Ok(await _mediatr.Send(command));


    [RemoveLazyCache]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> CreateComment([FromForm] CreateCommentCommand command)
        => Ok(await _mediatr.Send(command));
    
    
    [RemoveLazyCache]
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async ValueTask<IActionResult> DeleteComment([FromForm] DeleteCommentCommand command)
        => Ok(await _mediatr.Send(command));

    
    
    [RemoveLazyCache]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> UpdateComment([FromForm] UpdateCommentCommand command)
        => Ok(await _mediatr.Send(command));

    [Authorize]
    //[EnableRateLimiting("Api")]
    [AddLazyCache]
    [HttpGet("getall")]
    public async ValueTask<IActionResult> GetAllComment()
        => Ok(await _mediatr.Send(new GetAllCommentQuery()));

    
    [HttpGet("getById")]
    public async ValueTask<IActionResult> GetByIdComment([FromQuery] GetByIdCommentQuery command)
        => Ok(await _mediatr.Send(command));


}
