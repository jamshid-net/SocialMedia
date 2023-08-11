namespace SocialMedia.WebUI.GrpahqlServices;

public class PostService
{
    public async ValueTask<Guid> CreatePost([Service]ISender _mediatr, CreatePostCommand command)
       => await _mediatr.Send(command);
    public async ValueTask<bool> DeletePost([Service]ISender _mediatr, DeletePostCommand command)
            => await _mediatr.Send(command);
    public async ValueTask<bool> UpdatePost([Service]ISender _mediatr, UpdatePostCommand command)
            => await _mediatr.Send(command);
    public async ValueTask<List<PostGetDto>> GetAllPost([Service]ISender _mediatr)
            => await _mediatr.Send(new GetAllPostQuery());
    public async ValueTask<PostGetDto> GetByIdPost([Service]ISender _mediatr, GetByIdPostQuery command)
            => await _mediatr.Send(command);

}
