namespace SocialMedia.WebUI.GrpahqlServices;
[ExtendObjectType("Query")]
public class RoleService
{

    public async ValueTask<Guid> CreateRole([Service]ISender _mediatr, CreateRoleCommand command)
             => await _mediatr.Send(command);
    public async ValueTask<bool> DeleteRole([Service]ISender _mediatr, DeleteRoleCommand command)
            => await _mediatr.Send(command);
    public async ValueTask<bool> UpdateRole([Service]ISender _mediatr, UpdateRoleCommand command)
            => await _mediatr.Send(command);
    public async ValueTask<List<RoleGetDto>> GetAllRole([Service] ISender _mediatr)
           =>(await _mediatr.Send(new GetAllRoleQuery()));
    public async ValueTask<RoleGetDto> GetByIdRole([Service]ISender _mediatr, GetByIdRoleQuery command)
           => await _mediatr.Send(command);

}
