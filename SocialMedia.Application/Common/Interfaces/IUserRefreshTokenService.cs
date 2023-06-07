

namespace SocialMedia.Application.Common.Interfaces;
public interface IUserRefreshTokenService
{
    Task<bool> AuthenAsync(UserLoginCommand user);
    Task<UserRefreshToken> AddUserRefreshTokens(UserRefreshToken user, CancellationToken cancellationToken= default);

    Task<UserRefreshToken> UpdateUserRefreshTokens(UserRefreshToken user, CancellationToken cancellationToken = default);

    Task<UserRefreshToken> GetSavedRefreshTokens(string username, string refreshtoken);


    Task<bool> DeleteUserRefreshTokens(string username, string refreshToken, CancellationToken cancellationToken = default);

}
