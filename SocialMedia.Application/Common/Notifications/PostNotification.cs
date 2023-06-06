
namespace SocialMedia.Application.Common.Notifications;
public class PostNotification:INotification 
{
    public CreatePostCommand? CreatePostCommand { get; init; }
}
public class PostNotificationHandler : INotificationHandler<PostNotification>
{
    public Task Handle(PostNotification notification, CancellationToken cancellationToken)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(notification?.CreatePostCommand?.Title);
        Console.ResetColor();

        return Task.CompletedTask;
    }
}
