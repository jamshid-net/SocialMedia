namespace SocialMedia.Application.Comments.Command;
public class ReplyMessageCommentCommand : IRequest<CommentGetDto>
{
    public Guid ExistCommentId { get; init; }
    public string ReplyComment { get; init; }
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
        var entity = await _context.Comments.FindAsync(new object[] { request.ExistCommentId }, cancellationToken);
        if (entity is null)
            throw new NotFoundException(nameof(Comment), request.ExistCommentId);

        Comment replyComment = new Comment
        {
            Id = Guid.NewGuid(),
            AuthorId = _currentUserService.UserId,
            ReplyCommnet = entity,
            CommentText = request.ReplyComment,
            CreatedAt = DateTime.UtcNow,

        };
        _context.Comments.Add(replyComment);
        await _context.SaveChangesAsync(cancellationToken);
        var result = _mapper.Map<CommentGetDto>(entity);
        return result;
             
    }
   
}
