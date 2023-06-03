namespace SocialMedia.Application.Posts.Queries;
public class GetAllPostQuery:IRequest<IQueryable<PostGetDto>>
{
}
public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, IQueryable<PostGetDto>>
{
    public Task<IQueryable<PostGetDto>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
