namespace SocialMedia.Application.Comments.Command;
public class CreateCommentCommand:IRequest<Guid>
{
    public string CommentText { get; init; }
    
    public Guid PostId { get; init; } 
}
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public CreateCommentCommandHandler(IApplicationDbContext context,ICurrentUserService currentUserService)
           => (_context,_currentUserService) = (context,currentUserService);
    
    public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        Guid testUserId = Guid.Parse("2f71e502-edc4-4c66-bcb2-1a995594114a");
        var entity = new Comment
        {
            Id = Guid.NewGuid(),
            CommentText = request.CommentText,
            AuthorId = testUserId,
            PostId = request.PostId,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = "Jamshid"
            
        };
        await _context.Comments.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
