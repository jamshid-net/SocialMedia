namespace SocialMedia.Application.Permissions.Queries;
public class GetAllPermissionQuery:IRequest<IQueryable<PermissionGetDto>>
{
    
}
public class GetAllPermissionQueryHandler:IRequestHandler<GetAllPermissionQuery,IQueryable<PermissionGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPermissionQueryHandler(IApplicationDbContext context, IMapper mapper)
           => (_context, _mapper) = (context, mapper);

    public Task<IQueryable<PermissionGetDto>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
    {
         var entites = _context.Permissions as IQueryable<Permission>;
         var result = _mapper.Map<IQueryable<PermissionGetDto>>(entites); 

        return Task.FromResult(result);
    }
}
