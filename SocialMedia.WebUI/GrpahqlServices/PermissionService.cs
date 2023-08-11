namespace SocialMedia.WebUI.GrpahqlServices;

public class PermissionService
{
    public async ValueTask<Guid> CreatePermission([Service]ISender _mediatr, CreatePermissionCommand command)
         => await _mediatr.Send(command);
    public async ValueTask<bool> DeletePermission([Service]ISender _mediatr, DeletePermissionCommand command)
            => await _mediatr.Send(command);
    public async ValueTask<bool> UpdatePermission([Service]ISender _mediatr, UpdatePermissionCommand command)
           => await _mediatr.Send(command);
    public async ValueTask<List<PermissionGetDto>> GetAllPermission([Service] ISender _mediatr)
           => await _mediatr.Send( new GetAllPermissionQuery());
    public async ValueTask<PermissionGetDto> GetByIdPermission([Service]ISender _mediatr, GetByIdPermissionQuery command)
            =>await _mediatr.Send(command);

}
