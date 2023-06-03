namespace SocialMedia.Application.Roles.Queries;
public class GetByIdRoleQuery:IRequest<RoleGetDto>
{
    public Guid Id { get; init; }
}

public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQuery, RoleGetDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdRoleQueryHandler(IApplicationDbContext context,IMapper mapper)
           => (_context,_mapper) = (context,mapper);
    
    
    public async Task<RoleGetDto> Handle(GetByIdRoleQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Roles.FindAsync(new object[] { request.Id }, cancellationToken);
        if(entity is null)
            throw new NotFoundException(nameof(Role),request.Id);
        var result = _mapper.Map<RoleGetDto>(entity);
        return result;
    }
}
