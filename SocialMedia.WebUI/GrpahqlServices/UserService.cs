namespace SocialMedia.WebUI.GrpahqlServices;
[ExtendObjectType("Query")]
public class UserService
{
    public async ValueTask<Guid> CreateUser([Service]ISender _mediatr, CreateUserCommand command)
        => await _mediatr.Send(command);

    public async ValueTask<bool> DeleteUser([Service]ISender _mediatr, DeleteUserCommand command)
                     => await _mediatr.Send(command);

    public async ValueTask<bool> UpdateUser([Service]ISender _mediatr, UpdateUserCommand command)
            => await _mediatr.Send(command);

    public async ValueTask<List<UserGetDto>> GetAllUser([Service] ISender _mediatr)
            => await _mediatr.Send(new GetAllUsersQuery());

    public async ValueTask<UserGetDto> GetByIdUser([Service]ISender _mediatr, GetByIdUserQuery command)
              => await _mediatr.Send(command);


}
