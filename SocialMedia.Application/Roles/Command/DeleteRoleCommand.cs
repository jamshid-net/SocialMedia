namespace SocialMedia.Application.Roles.Command;
public class DeleteRoleCommand:IRequest<bool>
{
    public Guid Id { get; init; }
}
public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteRoleCommandHandler(IApplicationDbContext context)
           => _context = context;
    
    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var entity =await _context.Roles
            .FindAsync(new object[] { request.Id},cancellationToken);
        if(entity is null)
            throw new NotFoundException(nameof(Role),request.Id);
        _context.Roles.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;

    }
}

