
namespace SocialMedia.WebUI.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IApplicationDbContext _applicationDbContext;

    public CurrentUserService(IHttpContextAccessor httpcontextAccessor,IApplicationDbContext applicationDbContext)
          => (_httpContextAccessor,_applicationDbContext) = (httpcontextAccessor,applicationDbContext) ;
    public string? UserName => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
    public Guid? UserId => _applicationDbContext?.Users?.SingleOrDefault(x=> x.UserName == this.UserName)?.Id;

    
}
