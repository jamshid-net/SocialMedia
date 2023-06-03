using SocialMedia.Domain.Common;

namespace SocialMedia.Domain.Entities;

public class Post : BaseAuditableEntity
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Guid AuthorId { get; set; }
    public User Author { get; set; }

    public List<Comment>? Comments { get; set; }

}

