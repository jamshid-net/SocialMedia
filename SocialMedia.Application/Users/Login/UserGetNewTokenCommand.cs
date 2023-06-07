namespace SocialMedia.Application.Users.Login;
public class UserGetNewTokenCommand : IRequest<TokenResponse>
{
    public string OldToken { get; init; }
    public string RefreshToken { get; init; }
}
public class UserGetNewTokenCommandHandler : IRequestHandler<UserGetNewTokenCommand, TokenResponse>
{
    private readonly IUserRefreshTokenService _userRefreshTokenService;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMediator _mediator;

    public UserGetNewTokenCommandHandler(IUserRefreshTokenService userRefreshTokenService, IJwtTokenService jwtTokenService, IApplicationDbContext applicationDbContext, IMediator mediator)
    {
        _userRefreshTokenService = userRefreshTokenService;
        _jwtTokenService = jwtTokenService;
        _applicationDbContext = applicationDbContext;
        _mediator = mediator;
    }

    public async Task<TokenResponse> Handle(UserGetNewTokenCommand request, CancellationToken cancellationToken)
    {
        var principal = await _jwtTokenService.GetPrincipalFromExpiredToken(request.OldToken);
        var userName = principal.FindFirstValue(ClaimTypes.Name);
        var FoundUser = await _applicationDbContext.Users.SingleOrDefaultAsync(x => x.UserName == userName);
        if (FoundUser is null)
            throw new NotFoundException(nameof(User), userName);

        var savedRefreshToken = await _userRefreshTokenService.GetSavedRefreshTokens(FoundUser.UserName, request.RefreshToken);

        if (savedRefreshToken.RefreshToken != request.RefreshToken) //savedRefreshtoken ==null ||
            throw new NotFoundException("Token", request.RefreshToken);

        if (savedRefreshToken.ExpiresTime < DateTimeOffset.Now)
            throw new Exception("TOKEN TIME IS EXPIRED!");

        var result = await _jwtTokenService.CreateTokenAsync(userName);

        return result;


    }
}
