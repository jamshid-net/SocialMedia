namespace SocialMedia.Application.Users.Login;
public class UserLoginCommand : IRequest<TokenResponse>
{
    public string UserName { get; init; }

    public string Password { get; init; }

}
public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, TokenResponse>
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IConfiguration _configuration;
    private readonly IUserRefreshTokenService _userRefreshTokenService;
    public UserLoginCommandHandler(IJwtTokenService jwtTokenService, IConfiguration configuration, IUserRefreshTokenService userRefreshTokenService)
           =>(_jwtTokenService, _configuration, _userRefreshTokenService) = (jwtTokenService, configuration, userRefreshTokenService);
   

    public async Task<TokenResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        int time = 5;
        if (int.TryParse(_configuration.GetValue<string>("JWT:RefreshTokenExpiresTime"), out int t))
        {
            time = t;
        }
        var TokenResponsemodel =  await  _jwtTokenService.CreateTokenAsync(request);

        var userReshreshToken = new UserRefreshToken
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            ExpiresTime = DateTime.Now.AddMinutes(time),
            RefreshToken = TokenResponsemodel.RefreshToken
        };
        await _userRefreshTokenService.UpdateUserRefreshTokens(userReshreshToken);

        return TokenResponsemodel;
    }
}

