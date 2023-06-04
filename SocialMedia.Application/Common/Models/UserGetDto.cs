
namespace SocialMedia.Application.Common.Models;
public class UserGetDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string ProfilePicture { get; set; } 
    public Guid[]? RolesIds { get; set; }
    public DateOnly BirthDate { get; set; } 
    public List<Role> Roles { get; set; }
}
