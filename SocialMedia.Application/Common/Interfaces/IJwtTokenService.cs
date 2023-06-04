

using SocialMedia.Application.Users.Login;
using System.Security.Claims;

namespace SocialMedia.Application.Common.Interfaces;
public interface IJwtTokenService
{
    ValueTask<TokenResponse> CreateTokenAsync(UserLoginCommand userLogin); 
    ValueTask<string> GenerateRefreshTokenAsync(UserLoginCommand userLogin);
    ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);

}
