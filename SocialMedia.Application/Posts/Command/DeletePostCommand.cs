namespace SocialMedia.Application.Posts.Command;
public class DeletePostCommand:IRequest<bool>
{
    public Guid PostId { get; init; }

}
public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePostCommandHandler(IApplicationDbContext context)
           => _context = context;
    
    public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Posts.FindAsync(new object[] {request.PostId});
        if(entity == null)
        {
            throw new NotFoundException(nameof(Post),request.PostId);
        }
        _context.Posts.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken); 
        return true;

    }
}
