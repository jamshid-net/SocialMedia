namespace SocialMedia.Application.Common.Mappings;
public class CommentMapProfile:Profile
{
    public CommentMapProfile()
    {
        CreateMap<Comment, CommentGetDto>().ReverseMap();
    }
}
