namespace SocialMedia.Application.Common.Interfaces;
public interface ICurrentUserService
{
    string? UserName { get;}
    Guid? UserId { get;}
}
