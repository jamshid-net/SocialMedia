namespace SocialMedia.Domain.IdentityEntites;

public class Permission : BaseAuditableEntity
{
    public string PermissionName { get; set; }
    public virtual List<Role>? Roles { get; set; }
}

