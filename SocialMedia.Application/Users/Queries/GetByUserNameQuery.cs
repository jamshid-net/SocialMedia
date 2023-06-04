

namespace SocialMedia.Application.Users.Queries;

public class GetByUserNameQuery : IRequest<UserGetDto>
{
    public string UserName { get; init; }
}
public class GetByUserNameQueryHandler : IRequestHandler<GetByUserNameQuery, UserGetDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetByUserNameQueryHandler(IApplicationDbContext context, IMapper mapper)
            => (_context, _mapper) = (context, mapper);

    public async Task<UserGetDto> Handle(GetByUserNameQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Users.SingleOrDefaultAsync(x=>x.UserName == request.UserName, cancellationToken);

        if (entity is null)
            throw new NotFoundException(nameof(User), request.UserName);


        var result = _mapper.Map<UserGetDto>(entity);
        return result;
    }
}
