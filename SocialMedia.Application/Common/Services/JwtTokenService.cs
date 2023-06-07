

namespace SocialMedia.Application.Common.Services;
public class JwtTokenService : IJwtTokenService
{
    private readonly IMediator _mediatr;
    private readonly IConfiguration _configuration;
    private readonly IHashStringService _hashStringService;

    public JwtTokenService( IMediator mediatr, IConfiguration configuration, IHashStringService hashStringService)
            =>(_mediatr,_configuration,_hashStringService) = (mediatr,configuration,hashStringService);



    public async ValueTask<TokenResponse> CreateTokenAsync(string _UserName)
    {
        var foundUser = await _mediatr.Send(new GetByUserNameQuery() { UserName = _UserName });
        if (foundUser is null)
            throw new NotFoundException(nameof(UserLoginCommand), _UserName);
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, foundUser.UserName)
        };
        foreach (var role in foundUser.Roles)
        {
            foreach (var permission in role.Permissions)
            {
                if (permission.PermissionName is not null)
                    claims.Add(new Claim(ClaimTypes.Role, permission.PermissionName));
            }
        }

        int minute = 5;
        if (int.TryParse(_configuration.GetValue<string>("JWT:ExpiresInMinutes"), out int _minute)) {
            minute = _minute;
        }
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration.GetValue<string>("JWT:Issuer"),
            audience: _configuration.GetValue<string>("JWT:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(minute),
            signingCredentials:
                new SigningCredentials(
                        new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key"))),
                        SecurityAlgorithms.HmacSha256)

            );
        return new TokenResponse()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            RefreshToken = await GenerateRefreshTokenAsync(_UserName)
        };

    }

    public async ValueTask<string> GenerateRefreshTokenAsync(string userName)
    {
        string randomToken = await _hashStringService.GetHashStringAsync(userName + DateTime.UtcNow.ToString());
        return randomToken;
    }

    public ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidAudience = _configuration.GetValue<string>("JWT:Audience"),
            ValidIssuer = _configuration.GetValue<string>("JWT:Issuer"),
            ValidateLifetime = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key"))),


        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }


        return ValueTask.FromResult(principal);
    }
}
