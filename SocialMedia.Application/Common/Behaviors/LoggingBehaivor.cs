using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Common.Behaviors;
public class LoggingBehaivor<TRequest,TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaivor<TRequest, TResponse>> _logger;

    public LoggingBehaivor(ILogger<LoggingBehaivor<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogWarning($"Coming request is :{typeof(TRequest).Name}");
        var hatiko = await next();
        return hatiko;

    }
}
