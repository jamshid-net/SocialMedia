namespace SocialMedia.Infrastucture.Persistence.EntityConfigurations;
public class CommentConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);
       
    }
}
