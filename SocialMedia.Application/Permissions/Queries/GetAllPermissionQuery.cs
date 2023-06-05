namespace SocialMedia.Application.Permissions.Queries;
public class GetAllPermissionQuery:IRequest<List<PermissionGetDto>>
{
    
}
public class GetAllPermissionQueryHandler:IRequestHandler<GetAllPermissionQuery, List<PermissionGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPermissionQueryHandler(IApplicationDbContext context, IMapper mapper)
           => (_context, _mapper) = (context, mapper);

    public async Task<List<PermissionGetDto>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
    {
         var entites =await _context.Permissions.ToListAsync(cancellationToken);
         var result = _mapper.Map<List<PermissionGetDto>>(entites); 

        return result;
    }
}
