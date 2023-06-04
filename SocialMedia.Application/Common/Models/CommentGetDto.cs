namespace SocialMedia.Application.Common.Models;
public class CommentGetDto
{
    public Guid Id { get; set; }
    public string CommentText { get; set; }
    public Guid? AuthorId { get; set; }
    public Guid? PostId { get; set; }
}
