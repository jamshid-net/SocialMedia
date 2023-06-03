
namespace SocialMedia.Application.Users.Command;

public class CreateUserCommand : IRequest<Guid>
{
    public string FullName { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string ProfilePicture { get; init; }
    public string Password { get; init; }
    public DateOnly BirthDate { get; init; }
    public Guid[]? RoleIds { get; init; }

}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    private readonly IHashStringService _hashStringService;
   
    public CreateUserCommandHandler(IApplicationDbContext context, IHashStringService hashStringService)
           => (_context, _hashStringService) = (context, hashStringService);

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        string password = await _hashStringService.GetHashStringAsync(request.Password);
        var entity = new User
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            UserName = request.UserName,
            Email = request.Email,
            Password = password,
            ProfilePicture = request.ProfilePicture,
            BirthDate = request.BirthDate,
            CreatedAt = DateTimeOffset.Now,
            CreatedBy = request.UserName
             
        };
        if(request.RoleIds is not null)
        {
            foreach (Guid id in request.RoleIds)
            {
                entity.Roles.Add(new Role()
                {
                    Id = id
                });
            }
        }
      
        await _context.Users.AddAsync(entity,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}

