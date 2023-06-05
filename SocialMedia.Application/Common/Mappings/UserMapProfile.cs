namespace SocialMedia.Application.Common.Mappings;
public class UserMapProfile:Profile
{
    public  UserMapProfile()
    {
        CreateMap<UserGetDto, User>();
        CreateMap<User, UserGetDto>();
            
    }

}
