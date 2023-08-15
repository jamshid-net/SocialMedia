

namespace SocialMedia.WebUI.GrpahqlServices;

public static class GraphqlConfiguration
{
    public static IServiceCollection AddGraphqlServices(this IServiceCollection services)
    {
        services.AddGraphQLServer().RegisterService<ISender>().AddQueryType(x => x.Name("Query"))
            .AddType<CommentService>()
            .AddType<LoginService>()
            .AddType<LoginService>()
            .AddType<PermissionService>()
            .AddType<PostService>()
            .AddType<RoleService>()
            .AddType<UserService>();


        return services;
    }
}
