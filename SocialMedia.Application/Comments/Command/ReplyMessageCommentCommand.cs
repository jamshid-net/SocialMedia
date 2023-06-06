namespace SocialMedia.Application.Comments.Command;
public class ReplyMessageCommentCommand:IRequest<CommentGetDto>
{
    public Guid Id { get; init; } 
    public string Message { get; init; }
}
public class ReplyMessageCommentCommandHandler : IRequestHandler<ReplyMessageCommentCommand, CommentGetDto>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public ReplyMessageCommentCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        => (_context, _currentUserService, _mapper) = (context, currentUserService, mapper);

    public async Task<CommentGetDto> Handle(ReplyMessageCommentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Comments.FindAsync(new object[] { request.Id },cancellationToken);
        if(entity is null)
            throw new NotFoundException(nameof(Comment), request.Id);
        
        if(entity.InnerComments is null)
            entity.InnerComments = new List<Comment>();

        entity.InnerComments.Add(new Comment
        {
            Id = Guid.NewGuid(),
            AuthorId= _currentUserService.UserId,
            CommentText= request.Message,
            CreatedAt = DateTimeOffset.Now,
            PostId = entity.PostId,
            CreatedBy = _currentUserService.UserName

        });
        await _context.SaveChangesAsync(cancellationToken);
        var result =  _mapper.Map<CommentGetDto>(entity);
        return result;
    }
}
