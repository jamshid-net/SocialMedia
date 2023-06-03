
namespace SocialMedia.Application.Users.Command;

public class DeleteUserCommand : IRequest<bool>
{
    public Guid UserId { get; init; }

}
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
        => _context = context;
    
    

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity =await _context.Users.FindAsync(new object[] { request.UserId },cancellationToken);
        if(entity == null)
        {
            throw new NotFoundException(nameof(User),request.UserId);
        } 
        _context.Users.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
         
    }
}

