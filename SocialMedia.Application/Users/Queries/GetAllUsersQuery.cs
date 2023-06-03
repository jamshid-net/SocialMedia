namespace SocialMedia.Application.Users.Queries;
public class GetAllUsersQuery:IRequest<IQueryable<UserGetDto>>
{

}
public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IQueryable<UserGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IApplicationDbContext context, IMapper mapper)
     => (_context, _mapper) = (context, mapper);

    public async Task<IQueryable<UserGetDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var entities = _context.Users.Include(x=> x.Roles);
        var result = _mapper.Map<IQueryable<UserGetDto>>(entities);
        return result;
    }
}
