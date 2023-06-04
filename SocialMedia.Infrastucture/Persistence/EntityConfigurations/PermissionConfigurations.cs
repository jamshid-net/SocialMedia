namespace SocialMedia.Infrastucture.Persistence.EntityConfigurations;
public class PermissionConfigurations : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
