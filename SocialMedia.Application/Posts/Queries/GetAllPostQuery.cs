namespace SocialMedia.Application.Posts.Queries;
public class GetAllPostQuery:IRequest<List<PostGetDto>>
{
}
public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, List<PostGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPostQueryHandler(IApplicationDbContext context, IMapper mapper)
           => (_context, _mapper) = (context,mapper);
    
    
    public async  Task<List<PostGetDto>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
    {
        var entities =await _context.Posts.ToListAsync(cancellationToken);
        var result =  _mapper.Map<List<PostGetDto>>(entities);
        return result;

    }
}
