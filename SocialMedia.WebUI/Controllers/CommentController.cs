



namespace SocialMedia.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommentController : ApiBaseController
{
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> CreateComment([FromForm] CreateCommentCommand command)
        => Ok(await _mediatr.Send(command));

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async ValueTask<IActionResult> DeleteComment([FromForm] DeleteCommentCommand command)
        => Ok(await _mediatr.Send(command));


    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async ValueTask<IActionResult> UpdateComment([FromForm] UpdateCommentCommand command)
        => Ok(await _mediatr.Send(command));


    [HttpGet("getall")]
    public async ValueTask<IActionResult> GetAllComment()
        => Ok(await _mediatr.Send(new GetAllCommentQuery()));

    [HttpGet("getById")]
    public async ValueTask<IActionResult> GetByIdComment([FromQuery] GetByIdCommentQuery command)
        => Ok(await _mediatr.Send(command));
}
