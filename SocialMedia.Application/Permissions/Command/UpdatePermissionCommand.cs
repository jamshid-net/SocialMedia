using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Permissions.Command;

public class UpdatePermissionCommand : IRequest<bool>
{
    public Guid Id { get; init; }
    public string PermissionName { get; init; }
}
public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, bool>
{
    private IApplicationDbContext _context;
    private ICurrentUserService _currentUserService;

    public UpdatePermissionCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
           => (_context, _currentUserService) = (context, currentUserService);


    public async Task<bool> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Permissions.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity is null)
            throw new NotFoundException(nameof(Permission), request.Id);
        entity.PermissionName = request.PermissionName;
        entity.LastModified = DateTimeOffset.UtcNow;
        entity.LastModifiedBy = _currentUserService.UserName;
        
        await _context.SaveChangesAsync(cancellationToken);
        return true;

    }
}

