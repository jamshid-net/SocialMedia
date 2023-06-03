namespace SocialMedia.Application.Common.Mappings;
public class PostMapProfile:Profile
{
    public PostMapProfile()
    {
        CreateMap<Post, PostGetDto>().ReverseMap();
    }
}
