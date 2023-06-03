namespace SocialMedia.Application.Roles.Command;
public class CreateRoleCommand:IRequest<Guid>
{
    public string RoleName { get; init; }
    public Guid[]? PermissionIds { get; init; }
}
public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public CreateRoleCommandHandler(IApplicationDbContext context,ICurrentUserService currentUserService)
           => (_context,_currentUserService)=(context,currentUserService);
    
    
    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = new Role
        {
            Id = Guid.NewGuid(),
            RoleName = request.RoleName,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = _currentUserService.UserName            
        };
        if(request.PermissionIds is not null)
        {
            foreach(Guid permissionId in request.PermissionIds)
            {
                entity.Permissions.Add(new Permission
                {
                    Id = permissionId
                });
            }
        }
        await _context.Roles.AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;

    }
}

