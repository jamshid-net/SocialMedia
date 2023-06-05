
namespace SocialMedia.Domain.Entities;

public class Comment : BaseAuditableEntity
{
    public string CommentText { get; set; }

    public Guid? AuthorId { get; set; }
    public virtual User? Author { get; set; }
    public Guid? PostId { get; set; }
    public virtual Post? Post { get; set; }

}

