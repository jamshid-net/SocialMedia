using Microsoft.AspNetCore.DataProtection;
using System.Web;

namespace SocialMedia.Application.Users.Queries;
public class GetAllUsersQuery:IRequest<List<UserGetDto>>
{

}
public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserGetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDataProtector _dataProtector;

    public GetAllUsersQueryHandler(IApplicationDbContext context, IMapper mapper, IDataProtectionProvider protectProvider)
    {
        (_context, _mapper, _dataProtector) = (context, mapper,protectProvider.CreateProtector("SocialMedia.User.GetAll"));
    
    }

    public async Task<List<UserGetDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var entities =await _context.Users.ToListAsync(cancellationToken);
        var result = _mapper.Map<List<UserGetDto>>(entities);
        foreach (var entity in result)
        {
            string protectedId = _dataProtector.Protect(entity.Id);
            entity.Id = HttpUtility.UrlEncode(protectedId);
        }

        return result;
    }
}
