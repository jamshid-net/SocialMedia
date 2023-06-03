namespace SocialMedia.Application.Permissions.Command;
public class CreatePermissionCommand:IRequest<Guid> 
{
    public string PermissionName { get; init; }
}
public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, Guid>
{
    private IApplicationDbContext _context;
    private ICurrentUserService _currentUserService;

    public CreatePermissionCommandHandler(IApplicationDbContext context,ICurrentUserService currentUserService)
           => (_context,_currentUserService) = (context,currentUserService);
    
    

    public async Task<Guid> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Permission
        {
            Id = Guid.NewGuid(),
            PermissionName = request.PermissionName,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = _currentUserService.UserName
        };
        await _context.Permissions.AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;

    }
}
