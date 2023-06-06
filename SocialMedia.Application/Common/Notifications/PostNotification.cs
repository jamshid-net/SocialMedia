using Microsoft.AspNetCore.Http;

namespace SocialMedia.Application.Common.Notifications;
public class PostNotification:INotification 
{
    public HttpResponse? HttpResponse { get; init; }
}
public class PostNotificationHandler : INotificationHandler<PostNotification>
{
    public Task Handle(PostNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(notification?.HttpResponse?.ContentLength);

        return Task.CompletedTask;
    }
}
