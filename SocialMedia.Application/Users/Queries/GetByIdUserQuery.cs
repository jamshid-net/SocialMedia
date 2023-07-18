using Microsoft.AspNetCore.DataProtection;

namespace SocialMedia.Application.Users.Queries;
public class GetByIdUserQuery:IRequest<UserGetDto>
{
    public string UserId { get; init; }
}
public class GetByIdQueryHandler : IRequestHandler<GetByIdUserQuery, UserGetDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDataProtector _dataProtector;


    public GetByIdQueryHandler(IApplicationDbContext context, IMapper mapper, IDataProtectionProvider protectProvider)
            => (_context, _mapper, _dataProtector) = (context, mapper, protectProvider.CreateProtector("SocialMedia.User.GetById"));

    public async Task<UserGetDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var userGuid = Guid.Parse(_dataProtector.Unprotect(request.UserId));
        var entity= await _context.Users.FindAsync(new object[] { userGuid });    
           

        if (entity is null)
            throw new NotFoundException(nameof(User), request.UserId);
        
        
        var result = _mapper.Map<UserGetDto>(entity);   
        return result;
    }
}
