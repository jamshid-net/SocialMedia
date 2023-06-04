namespace SocialMedia.Domain.Entities;

public class User : BaseAuditableEntity
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string ProfilePicture { get; set; }
    public string Password { get; set; }
    public DateOnly BirthDate { get; set; }
    public List<Post>? Posts { get; set; }
    [JsonIgnore]
    public List<Comment>? Comments { get; set; }
    [JsonIgnore]
    public List<Role>? Roles { get; set; }

}

