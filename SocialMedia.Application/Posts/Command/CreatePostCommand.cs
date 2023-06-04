namespace SocialMedia.Application.Posts.Command;
public class CreatePostCommand : IRequest<Guid>
{
    public string Title { get; init; }
    public string Content { get; init; }
   
}
public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand,Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    public CreatePostCommandHandler(IApplicationDbContext context,ICurrentUserService currentUserService)
           => (_context,_currentUserService) = (context,currentUserService);
    
    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var entity = new Post
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Content = request.Content,
            AuthorId = _currentUserService.UserId,
            CreatedAt = DateTimeOffset.UtcNow,
            CreatedBy = _currentUserService.UserName
        };
       
        await _context.Posts.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;   
    }
}
