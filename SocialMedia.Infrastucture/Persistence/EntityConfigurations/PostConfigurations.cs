namespace SocialMedia.Infrastucture.Persistence.EntityConfigurations;
public class PostConfigurations : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
    }
}
