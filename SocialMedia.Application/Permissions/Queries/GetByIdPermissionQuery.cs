namespace SocialMedia.Application.Permissions.Queries;
public class GetByIdPermissionQuery:IRequest<PermissionGetDto>
{
    public Guid Id { get; init; }
}
public class GetByIdPermissionQueryHandler : IRequestHandler<GetByIdPermissionQuery, PermissionGetDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdPermissionQueryHandler(IApplicationDbContext context, IMapper mapper)
           => (_context, _mapper) = (context, mapper);

    public async Task<PermissionGetDto> Handle(GetByIdPermissionQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Permissions.FindAsync(new object[] { request.Id },cancellationToken);
        if(entity is null)
            throw new NotFoundException(nameof(Permission),request.Id);
        var result = _mapper.Map<PermissionGetDto>(entity);
        return result;
    }
}
