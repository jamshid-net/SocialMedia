namespace SocialMedia.WebUI.GrpahqlServices;


[ExtendObjectType("Query")]
public class CommentService
{
    public async ValueTask<CommentGetDto> ReplyComment([Service] ISender _mediatr,ReplyMessageCommentCommand command)
       => await _mediatr.Send(command);


    public async ValueTask<Guid> CreateComment([Service] ISender _mediatr,CreateCommentCommand command)
      => await _mediatr.Send(command);


    public async ValueTask<bool> DeleteComment([Service] ISender _mediatr,DeleteCommentCommand command)
       => await _mediatr.Send(command);

    public async ValueTask<bool> UpdateComment([Service] ISender _mediatr, UpdateCommentCommand command)
       => await _mediatr.Send(command);


    public async ValueTask<List<CommentGetDto>> GetAllComment([Service] ISender _mediatr)
       => await _mediatr.Send(new GetAllCommentQuery());


    public async ValueTask<CommentGetDto> GetByIdComment([Service] ISender _mediatr,GetByIdCommentQuery command)
       => await _mediatr.Send(command);


}
