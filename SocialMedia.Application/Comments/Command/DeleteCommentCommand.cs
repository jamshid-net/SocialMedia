namespace SocialMedia.Application.Comments.Command;
public class DeleteCommentCommand:IRequest<bool>
{
    public Guid CommentId { get; init; }
}
public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
{
    private readonly IApplicationDbContext _context;
    public DeleteCommentCommandHandler(IApplicationDbContext context)
           => _context = context;
    
    
    public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Comments
            .FindAsync(new object[] { request.CommentId }, cancellationToken); 
        if(entity is null)
            throw new NotFoundException(nameof(Comment),request.CommentId);
        
        
        _context.Comments.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
