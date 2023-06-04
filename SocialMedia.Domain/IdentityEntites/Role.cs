
namespace SocialMedia.Domain.IdentityEntites;
public class Role : BaseAuditableEntity
{
    public string RoleName { get; set; }
    public virtual List<Permission> Permissions { get; set; }
    public List<User>? UserRoles { get; set; }
}

