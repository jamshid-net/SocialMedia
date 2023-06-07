
namespace SocialMedia.Application.Common.Interfaces;
public interface IJwtTokenService
{
    ValueTask<TokenResponse> CreateTokenAsync(string userName); 
    ValueTask<string> GenerateRefreshTokenAsync(string userName);
    ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);

}
