namespace SocialMedia.Application.Common.Mappings;
public class RoleMapProfile:Profile
{
    public RoleMapProfile()
    {
        CreateMap<Role, RoleGetDto>().ReverseMap();
    }
}
