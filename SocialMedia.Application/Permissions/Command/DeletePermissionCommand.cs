namespace SocialMedia.Application.Permissions.Command;
public class DeletePermissionCommand:IRequest<bool>
{
    public Guid Id { get; init; }
}
public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePermissionCommandHandler(IApplicationDbContext context)
           => _context = context;
    
    

    public async Task<bool> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Permissions.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity is null)
            throw new NotFoundException(nameof(Permission), request.Id);
        _context.Permissions.Remove(entity); 
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
