namespace SocialMedia.WebUI.GrpahqlServices;

public static class GraphqlConfiguration
{
    public static IServiceCollection AddGraphqlServices(this IServiceCollection services)
    {
        services.AddGraphQLServer().AddQueryType<CommentService>();
        //services.AddGraphQLServer().AddQueryType<LoginService>();
        //services.AddGraphQLServer().AddQueryType<PermissionService>();
        //services.AddGraphQLServer().AddQueryType<PostService>();
        //services.AddGraphQLServer().AddQueryType<RoleService>();
        //services.AddGraphQLServer().AddQueryType<UserService>();
        return services;
    }
}
