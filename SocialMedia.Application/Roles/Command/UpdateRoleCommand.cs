namespace SocialMedia.Application.Roles.Command;

public class UpdateRoleCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string RoleName { get; init; }
    public Guid[]? PermissionIds { get; init; }
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
        
        if (request.PermissionIds is not null)
        {
            foreach (Guid permissionId in request.PermissionIds)
            {
                entity.Permissions.Add(new Permission
                {
                    Id = permissionId
                });
            }
        }
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}