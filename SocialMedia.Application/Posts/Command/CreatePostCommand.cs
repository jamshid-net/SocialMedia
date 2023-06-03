namespace SocialMedia.Application.Posts.Command;
public class CreatePostCommand : IRequest<Guid>
{
    public string Title { get; init; }
    public string Content { get; init; }
    public Guid AuthorId { get; init; }
}
public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand,Guid>
{
    private readonly IApplicationDbContext _context;
    public CreatePostCommandHandler(IApplicationDbContext context)
           => _context = context;
    
    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var entity = new Post
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Content = request.Content,
            AuthorId = request.AuthorId,
            CreatedAt = DateTimeOffset.UtcNow,
        };
        await _context.Posts.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;   
    }
}
