namespace SocialMedia.Application.Common.Models;
public class PostGetDto
{
    public Guid Id { get; set; }  
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid AuthorId { get; set; }
    public Guid[] CommentIds { get; set; }
}
