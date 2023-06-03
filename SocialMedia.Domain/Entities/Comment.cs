using SocialMedia.Domain.Common;

namespace SocialMedia.Domain.Entities
{
    public class Comment :BaseAuditableEntity
    {
        public string CommentText { get; set; } 

        public Guid? AuthorId { get; set; }
        public User? Author { get; set; }

        public Guid? PostId { get; set; }
        public Post? Post { get; set; }

    }
}
