namespace SocialMedia.Application.Common.Mappings;
public class PermissionMapProfile:Profile
{
    public PermissionMapProfile()
    {
        CreateMap<Permission, PermissionGetDto>().ReverseMap();
    }
}
