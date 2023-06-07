


namespace SocialMedia.WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIService(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddHttpContextAccessor();
        services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            {
                return RateLimitPartition.GetFixedWindowLimiter(partitionKey: httpContext.Request.Headers.Host.ToString(),
                    partition =>
                    new FixedWindowRateLimiterOptions
                    {
                        QueueLimit = 3,
                        PermitLimit = 6,
                        AutoReplenishment = true,
                        Window = TimeSpan.FromSeconds(60),

                    });
                //new ConcurrencyLimiterOptions
                //{
                //    PermitLimit = 5,
                //    QueueLimit = 3,
                //    QueueProcessingOrder = QueueProcessingOrder.OldestFirst
                //};


            });
            options.OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.HttpContext.Response.WriteAsync("Too many requests. Please try later again... ", cancellationToken: token);
            };
        });
        return services;
    }
}
