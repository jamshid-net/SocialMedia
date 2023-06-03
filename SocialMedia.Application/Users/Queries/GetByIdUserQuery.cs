namespace SocialMedia.Application.Users.Queries;
public class GetByIdUserQuery:IRequest<UserGetDto>
{
    public Guid UserId { get; init; }
}
public class GetByIdQueryHandler : IRequestHandler<GetByIdUserQuery, UserGetDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
            => (_context, _mapper) = (context, mapper);

    public async Task<UserGetDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var entity=await _context.Users.FindAsync(new object[] {request.UserId}, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        var result = _mapper.Map<UserGetDto>(entity);   
        return result;
    }
}
