namespace SocialMedia.Application.Posts.Command;

public class UpdatePostCommand : IRequest<bool>
{
    public Guid PostId { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }

}
public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, bool>
{
    private readonly IApplicationDbContext _context;
    public UpdatePostCommandHandler(IApplicationDbContext context)
           => _context = context;

    public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Posts.FindAsync(new object[] { request.PostId });
        if (entity == null)
        {
            throw new NotFoundException(nameof(Post), request.PostId);
        }
        entity.Id = Guid.NewGuid();
        entity.Title = request.Title;
        entity.Content = request.Content;
        entity.LastModified = DateTimeOffset.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
