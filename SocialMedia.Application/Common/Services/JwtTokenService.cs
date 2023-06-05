
using SocialMedia.Application.Users.Queries;
using System.IdentityModel.Tokens.Jwt;

namespace SocialMedia.Application.Common.Services;
public class JwtTokenService : IJwtTokenService
{
    private readonly IMediator _mediatr;
    private readonly IConfiguration _configuration;
    private readonly IHashStringService _hashStringService;

    public JwtTokenService( IMediator mediatr, IConfiguration configuration, IHashStringService hashStringService)
            =>(_mediatr,_configuration,_hashStringService) = (mediatr,configuration,hashStringService);
    
    

    public async ValueTask<TokenResponse> CreateTokenAsync(UserLoginCommand userLogin)
    {
        var foundUser = await _mediatr.Send(new GetByUserNameQuery() { UserName = userLogin.UserName });
        if(foundUser is null) 
            throw new NotFoundException(nameof(UserLoginCommand), userLogin.UserName);
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, foundUser.UserName)
        };
        foreach(var role in foundUser.Roles)
        {
            foreach(var permission in role.Permissions)
            {
                if(permission.PermissionName is not  null)
                claims.Add(new Claim(ClaimTypes.Role, permission.PermissionName));
            }
        }

        int minute = 5;
        if(int.TryParse(_configuration.GetRequiredSection("JWT:ExpiresInMinutes").Value,out int _minute)){
            minute = _minute;
        }
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer:_configuration.GetRequiredSection("").Value


            );
        return new TokenResponse();

    }

    public ValueTask<string> GenerateRefreshTokenAsync(UserLoginCommand userLogin)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
    {
        throw new NotImplementedException();
    }
}
