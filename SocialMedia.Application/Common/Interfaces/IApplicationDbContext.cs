

namespace SocialMedia.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; }
    public DbSet<Post> Posts { get; }
    public DbSet<Comment> Comments { get; }

    public DbSet<Role> Roles { get; }
    public DbSet<Permission> Permissions { get; }

    public DbSet<UserRefreshToken> UserRefreshTokens { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

