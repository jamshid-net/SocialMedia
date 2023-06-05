namespace SocialMedia.Application.Comments.Queries;
public class GetAllCommentQuery : IRequest<List<CommentGetDto>>
{

}
public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, List<CommentGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllCommentQueryHandler(IApplicationDbContext context, IMapper mapper)
           => (_context, _mapper) = (context, mapper);
    public async Task<List<CommentGetDto>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context.Comments.ToListAsync(cancellationToken);
        var result = _mapper.Map<List<CommentGetDto>>(entities);
        return result;
    }
}
