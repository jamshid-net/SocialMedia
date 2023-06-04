using SocialMedia.Application.Common.Interfaces;

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
    private readonly ICurrentUserService _currentUserService;
    public UpdatePostCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
           => (_context, _currentUserService) = (context, currentUserService);

    public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Posts
            .FindAsync(new object[] { request.PostId },cancellationToken);
        if (entity is null)
            throw new NotFoundException(nameof(Post), request.PostId);
       
        //command property if null, not sets value
        var properties = typeof(UpdatePostCommand).GetProperties();
        foreach (var property in properties)
        {
            var requestValue = property.GetValue(request);
            if (requestValue is not null)
            {
                var entityProperty = entity.GetType().GetProperty(property.Name);
                entityProperty.SetValue(entity, requestValue);
            }
        }
        
        entity.LastModified = DateTimeOffset.UtcNow;
        entity.LastModifiedBy = _currentUserService.UserName;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
