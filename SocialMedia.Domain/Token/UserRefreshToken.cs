namespace SocialMedia.Domain.Token;
public class UserRefreshToken
{
    public Guid Id { get; set; }
    public string RefreshToken { get; set; }
    public string UserName { get; set; }
    public DateTimeOffset ExpiresTime { get; set; }

}
