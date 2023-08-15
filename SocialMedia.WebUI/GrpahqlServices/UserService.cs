namespace SocialMedia.WebUI.GrpahqlServices;
[ExtendObjectType("Query")]
public class UserService
{

    public async ValueTask<Guid> CreateUser(ISender _mediatr, CreateUserCommand command)
        => await _mediatr.Send(command);

    public async ValueTask<bool> DeleteUser(ISender _mediatr, DeleteUserCommand command)
                     => await _mediatr.Send(command);

    public async ValueTask<bool> UpdateUser(ISender _mediatr, UpdateUserCommand command)
            => await _mediatr.Send(command);

    public async ValueTask<List<UserGetDto>> GetAllUser( ISender _mediatr)
            => await _mediatr.Send(new GetAllUsersQuery());

    public async ValueTask<UserGetDto> GetByIdUser(ISender _mediatr, GetByIdUserQuery command)
              => await _mediatr.Send(command);


}
