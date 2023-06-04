namespace SocialMedia.Application.Users.Login;
public class UserLoginCommand:IRequest<TokenResponse>
{
    public string UserName { get; init; }

    public string Password { get; init; }

}
public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, TokenResponse>
{
    public Task<TokenResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
