using System.Diagnostics;
using Cortex.Mediator.Commands;
using Cortex.Mediator.Queries;
using Microsoft.Extensions.Logging;

namespace OrderManagement.Application.Common.Behaviours;
public class PerformanceBehaviour<TRequest, TResponse>(
    ILogger<TRequest> logger) : ICommandPipelineBehavior<TRequest, TResponse> , IQueryPipelineBehavior<TRequest, TResponse> 
        where TRequest : ICommand<TResponse> , IQuery<TResponse>
{
    private readonly Stopwatch _timer = new();

    public async Task<TResponse> Handle(TRequest command, CommandHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;


            logger.LogWarning("OrderManagement Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) :{Request}",
                requestName, elapsedMilliseconds, command);
        }

        return response;
    }

    public async Task<TResponse> Handle(TRequest query, QueryHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;


            logger.LogWarning("OrderManagement Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds)",
                requestName, elapsedMilliseconds);
        }

        return response;
    }
}
