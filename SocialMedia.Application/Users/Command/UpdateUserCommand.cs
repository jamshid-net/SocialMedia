
namespace SocialMedia.Application.Users.Command;

public class UpdateUserCommand : IRequest<bool>
{
    public Guid Id { get; init; }
    public string FullName { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string ProfilePicture { get; init; }
    public string Password { get; init; }
    public DateOnly BirthDate { get; init; }
    public Guid[] RoleIds { get; init; }

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
        
        
        entity.FullName = request.FullName;
        entity.UserName = request.UserName;
        entity.Email = request.Email;
        entity.Password = password;
        entity.ProfilePicture = request.ProfilePicture;
        entity.BirthDate = request.BirthDate;
        entity.LastModified = DateTimeOffset.Now;
        entity.LastModifiedBy = request.UserName;

        foreach (Guid id in request.RoleIds)
        {
            entity.Roles.Add(new Role()
            {
                Id = id
            });
        }
        
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

}



