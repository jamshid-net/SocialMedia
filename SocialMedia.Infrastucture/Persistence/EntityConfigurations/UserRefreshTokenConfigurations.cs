
namespace SocialMedia.Infrastucture.Persistence.EntityConfigurations;
public class UserRefreshTokenConfigurations : IEntityTypeConfiguration<UserRefreshToken>
{
    public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
    {
        builder.HasKey(x => x.Id);
       
    }
}
