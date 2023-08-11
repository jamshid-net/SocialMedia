namespace SocialMedia.WebUI.GrpahqlServices;

public class LoginService
{
    public async ValueTask<TokenResponse> Login([Service] ISender _mediatr, UserLoginCommand command)
          => await _mediatr.Send(command);

    public async ValueTask<TokenResponse> RefreshToken([Service]ISender _mediatr, UserGetNewTokenCommand command)
        => await _mediatr.Send(command);
}
