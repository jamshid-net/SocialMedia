namespace SocialMedia.Domain.IdentityEntites;

public class Permission : BaseAuditableEntity
{
    public string? PermissionName { get; set; }
    [JsonIgnore]
    public virtual List<Role>? Roles { get; set; }
}

