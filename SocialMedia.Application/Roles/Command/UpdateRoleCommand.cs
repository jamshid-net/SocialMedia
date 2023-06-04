namespace SocialMedia.Application.Roles.Command;

public class UpdateRoleCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string RoleName { get; init; }
    public List<Guid>? PermissionsIds { get; init; }
}
public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, bool>
{
    private readonly IApplicationDbContext _context;

    private readonly ICurrentUserService _currentUserService;

    public UpdateRoleCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
           => (_context, _currentUserService) = (context, currentUserService);

    public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        
        var entity = await _context.Roles
            .FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity is null)
            throw new NotFoundException(nameof(Role), request.Id);
        
        entity.RoleName = request.RoleName;
        entity.LastModified = DateTimeOffset.UtcNow;
        entity.LastModifiedBy = _currentUserService.UserName;
        if (request.PermissionsIds is not null)
        {
            List<Permission> foundPermissions = new();
            foreach (var item in request.PermissionsIds)
            {
                var permisson = await _context.Permissions.FindAsync(new object[] { item });
                foundPermissions.Add(permisson);
            }
            entity.Permissions = foundPermissions;
        }


        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}