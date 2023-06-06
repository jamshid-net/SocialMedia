
namespace SocialMedia.Domain.Entities;

public class Post : BaseAuditableEntity
{
    public string Title { get; set; }
    public string Content { get; set; }

    public  Guid? AuthorId { get; set; }
    public virtual User? Author { get; set; }

   
}

