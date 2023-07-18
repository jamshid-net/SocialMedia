

using Microsoft.AspNetCore.DataProtection;

namespace SocialMedia.Application.Users.Queries;

public class GetByUserNameQuery : IRequest<UserGetDto>
{
    public string UserName { get; init; }
}
public class GetByUserNameQueryHandler : IRequestHandler<GetByUserNameQuery, UserGetDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDataProtector _dataProtector;

    public GetByUserNameQueryHandler(IApplicationDbContext context, IMapper mapper, IDataProtectionProvider protectProvider)
            => (_context, _mapper, _dataProtector) = (context, mapper, protectProvider.CreateProtector("SocialMedia.User.GetByName"));

    public async Task<UserGetDto> Handle(GetByUserNameQuery request, CancellationToken cancellationToken)
    {


        var entity = await _context.Users.SingleOrDefaultAsync(x=>x.UserName == request.UserName, cancellationToken);
        if (entity is null)
            throw new NotFoundException(nameof(User), request.UserName);

        var result = _mapper.Map<UserGetDto>(entity);
        return result;
    }
}
