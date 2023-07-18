using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace SocialMedia.Application.Common.Behaviors;
public class LoggingBehaivorPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull 
{
    private readonly ILogger<LoggingBehaivorPreProcessor<TRequest>> _logger;

    public LoggingBehaivorPreProcessor(ILogger<LoggingBehaivorPreProcessor<TRequest>> logger)
    {
        _logger = logger;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _logger.LogWarning($"Coming request PREPROCCESSOR: {typeof(TRequest).Name}");
        return Task.CompletedTask;
    }
}
