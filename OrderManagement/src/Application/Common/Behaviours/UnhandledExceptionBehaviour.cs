using Cortex.Mediator.Commands;
using Cortex.Mediator.Queries;
using Microsoft.Extensions.Logging;

namespace OrderManagement.Application.Common.Behaviours;
public class UnhandledExceptionBehaviour<TRequest, TResponse>
    : ICommandPipelineBehavior<TRequest, TResponse>, IQueryPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>, IQuery<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest command, CommandHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "OrderManagement Command: Unhandled Exception for Command {Name} {Request}", requestName, command);

            throw;
        }
    }

    public async Task<TResponse> Handle(TRequest query, QueryHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "OrderManagement Query: Unhandled Exception for Query {Name} {Request}", requestName, query);

            throw;
        }
    }
}
