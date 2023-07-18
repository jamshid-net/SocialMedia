
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;

namespace SocialMedia.Infrastucture.Persistence;
public class ApplicationDbContext : DbContext, IApplicationDbContext, IDataProtectionKeyContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
       
    }
    public DbSet<User> Users { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
       
        base.OnModelCreating(modelBuilder);
    }
   
}
