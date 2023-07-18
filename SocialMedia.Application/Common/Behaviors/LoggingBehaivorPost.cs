using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Common.Behaviors;
public class LoggingBehaivorPost<TResquest, TResponse> : IRequestPostProcessor<TResquest, TResponse>
    where TResquest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaivorPost<TResquest, TResponse>> _logger;

    public LoggingBehaivorPost(ILogger<LoggingBehaivorPost<TResquest, TResponse>> logger)
    {
        _logger = logger;
    }

    public  Task Process(TResquest request, TResponse response, CancellationToken cancellationToken)
    {
        _logger.LogWarning($"Used this request after posting:{typeof(TResquest).Name}");
        return Task.CompletedTask;
    }
}
