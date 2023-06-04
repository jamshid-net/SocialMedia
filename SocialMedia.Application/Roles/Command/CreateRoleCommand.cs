namespace SocialMedia.Application.Roles.Command;
public class CreateRoleCommand:IRequest<Guid>
{
    public string RoleName { get; init; }
    public List<Guid>? PermissionsIds { get; init; }
}
public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IApplicationDbContext context,ICurrentUserService currentUserService,IMapper mapper)
           => (_context,_currentUserService,_mapper)=(context,currentUserService,mapper);
    
    
    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        
        
       
        var entity = new Role
        {
            Id = Guid.NewGuid(),
            RoleName = request.RoleName,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = _currentUserService.UserName,
           

        };

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


        await _context.Roles.AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;

    }
}

