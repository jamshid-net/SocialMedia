namespace SocialMedia.Application.Posts.Queries;
public class GetByIdPostQuery:IRequest<PostGetDto>
{
    public Guid PostId { get; init; }
}
public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQuery, PostGetDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetByIdPostQueryHandler(IApplicationDbContext context,IMapper mapper)
           => (_context ,_mapper) = (context,mapper);
    
    
    public async Task<PostGetDto> Handle(GetByIdPostQuery request, CancellationToken cancellationToken)
    {
        var entity =await _context.Posts.FindAsync(new object[] {request.PostId}, cancellationToken);
        if(entity == null)
        {
            throw new NotFoundException(nameof(Post), request.PostId);
        }
        var result = _mapper.Map<PostGetDto>(entity);   
        return result;

    }
}
