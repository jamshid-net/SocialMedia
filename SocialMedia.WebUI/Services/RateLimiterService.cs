namespace SocialMedia.WebUI.Services;

public static class RateLimiterService
{
    public static IServiceCollection AddRateLimiterService(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {

            options.AddFixedWindowLimiter("Api", options =>
            {
                options.AutoReplenishment = true;
                options.PermitLimit = 5;
                options.Window = TimeSpan.FromSeconds(10);

            });
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            {
                return RateLimitPartition.GetFixedWindowLimiter(partitionKey: httpContext.Request.Headers.Host.ToString(),
                    partition =>
                    new FixedWindowRateLimiterOptions
                    {
                        QueueLimit = 3,
                        PermitLimit = 10,
                        AutoReplenishment = true,
                        Window = TimeSpan.FromSeconds(10),

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
