namespace SocialMedia.Application.Common.Mappings;
public class PostMapProfile:Profile
{
    public PostMapProfile()
    {
        CreateMap<Post, PostGetDto>()
            .ForMember(dest => dest.CommentIds, opt => opt.MapFrom<CommentsToCommentIdsResolver>());
        CreateMap<PostGetDto, Post>();

    }
}
public class CommentsToCommentIdsResolver : IValueResolver<Post, PostGetDto, Guid[]>
{
    public Guid[] Resolve(Post source, PostGetDto destination, Guid[] destMember, ResolutionContext context)
    {
        var commentIds = new List<Guid>();
        if (source.Comments != null)
        {
            foreach (var comment in source.Comments)
            {
                commentIds.Add(comment.Id);
            }
        }

        return commentIds.ToArray();
    }
}