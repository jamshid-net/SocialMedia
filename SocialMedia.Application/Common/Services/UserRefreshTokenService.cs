

namespace SocialMedia.Application.Common.Services;
public class UserRefreshTokenService: IUserRefreshTokenService
{

    private readonly IHashStringService _hashStringService;
    private readonly IApplicationDbContext _dbContext;
    private readonly IMediator _mediator;


    public UserRefreshTokenService(ICurrentUserService userService, IHashStringService hashStringService, IApplicationDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _hashStringService = hashStringService;
        _mediator = mediator;
    }
    public async Task<UserRefreshToken> AddUserRefreshTokens(UserRefreshToken user, CancellationToken cancellationToken = default)
    {
       
            _dbContext.UserRefreshTokens.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user;
        
    }


    public async Task<bool> AuthenAsync(UserLoginCommand user)
    {
        string hashedPassword = await _hashStringService.GetHashStringAsync(user.Password);
        var result = await _dbContext.Users.SingleOrDefaultAsync(x => x.UserName == user.UserName && x.Password == hashedPassword);
        if(result is not null)
            return true;
        else return false;
    }



    public async Task<bool> DeleteUserRefreshTokens(string username, string refreshToken, CancellationToken cancellationToken = default) 
    {
      
            var userRefreshtone = _dbContext.UserRefreshTokens
                .FirstOrDefault(x => x.UserName == username && refreshToken == x.RefreshToken);
            _dbContext.UserRefreshTokens.Remove(userRefreshtone);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        
    }


    public async Task<UserRefreshToken> GetSavedRefreshTokens(string username, string refreshtoken)
    {
        return await Task.FromResult(_dbContext.UserRefreshTokens
            .FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshtoken));
    }

    public async Task<UserRefreshToken> UpdateUserRefreshTokens(UserRefreshToken user, CancellationToken cancellationToken = default)
    {
        var res = await _dbContext.UserRefreshTokens
            .FirstOrDefaultAsync(x => x.UserName == user.UserName);
        if (res == null)
        {
            await AddUserRefreshTokens(user);
            return user;
        }
        else
        {
            res.RefreshToken = user.RefreshToken;
            res.ExpiresTime = user.ExpiresTime;
            _dbContext.UserRefreshTokens.Update(res);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user;
        }
    }

   
}
