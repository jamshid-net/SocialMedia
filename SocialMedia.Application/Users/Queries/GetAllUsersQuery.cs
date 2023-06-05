

namespace SocialMedia.Application.Users.Queries;
public class GetAllUsersQuery:IRequest<List<UserGetDto>>
{

}
public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IApplicationDbContext context, IMapper mapper)
     => (_context, _mapper) = (context, mapper);

    public async Task<List<UserGetDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var entities =await _context.Users.ToListAsync(cancellationToken);
        var result = _mapper.Map<List<UserGetDto>>(entities);
        return result;
    }
}
