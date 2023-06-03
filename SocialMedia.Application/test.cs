using Microsoft.AspNetCore.Http;

namespace SocialMedia.Application;
public abstract class test : HttpContext
{

    protected IApplicationDbContext _context
         => RequestServices.GetRequiredService<IApplicationDbContext>();

}
