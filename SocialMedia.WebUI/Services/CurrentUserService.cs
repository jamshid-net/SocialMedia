using SocialMedia.Application.Common.Interfaces;
using System.Security.Claims;

namespace SocialMedia.WebUI.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor contextAccessor)
          => _httpContextAccessor = contextAccessor;



    public string? UserName => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
