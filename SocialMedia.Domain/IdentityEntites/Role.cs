
namespace SocialMedia.Domain.IdentityEntites;
public class Role : BaseAuditableEntity
{
    public string RoleName { get; set; }
    [JsonIgnore]
    public virtual List<Permission> Permissions { get; set; }
    [JsonIgnore]
    public List<User>? UserRoles { get; set; }
}

