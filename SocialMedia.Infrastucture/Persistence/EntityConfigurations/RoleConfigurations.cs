namespace SocialMedia.Infrastucture.Persistence.EntityConfigurations;
public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
