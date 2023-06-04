
namespace SocialMedia.Application.Users.Command;

public class UpdateUserCommand : IRequest<bool>
{
    public Guid Id { get; init; }
    public string? FullName { get; init; }
    public string? UserName { get; init; }
    public string? Email { get; init; }
    public string? ProfilePicture { get; init; }
    public string? Password { get; init; }
    public DateOnly BirthDate { get; init; }
    public Guid[]? RoleIds { get; init; }

}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IApplicationDbContext _context;

    private readonly IHashStringService _hashStringService;
    public UpdateUserCommandHandler(IApplicationDbContext context, IHashStringService hashStringService)
           => (_context,_hashStringService) = (context, hashStringService);
        
    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        string password = await _hashStringService.GetHashStringAsync(request.Password);
        var entity = await _context.Users
            .FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity is null)
            throw new NotFoundException(nameof(User), request.Id);
        

        //command property if null, not sets value
        var properties = typeof(UpdateUserCommand).GetProperties(); 
        foreach (var property in properties)
        {
            var requestValue = property.GetValue(request);
            if(requestValue is not null)
            {
                var entityProperty = entity.GetType().GetProperty(property.Name);
                entityProperty.SetValue(entity, requestValue);
            }
        }

        entity.LastModified = DateTimeOffset.Now;
        entity.LastModifiedBy = request.UserName;
        if (request.RoleIds is not null)
        {
            List<Role> foundRoles = new();

            foreach (var roleId in request.RoleIds)
            {
                var role = await _context.Roles.FindAsync(new object[] { roleId });
                foundRoles.Add(role);
            }
            entity.Roles = foundRoles;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

}



