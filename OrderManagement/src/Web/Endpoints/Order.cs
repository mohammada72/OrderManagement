using Cortex.Mediator;
using OrderManagement.Application.CreateOrder;
using OrderManagement.Domain.Entities;
using OrderManagement.Web.Infrastructure;

namespace OrderManagement.Web.Endpoints;
public class OrderEndpoint : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost(CreateOrder);
    }

    public async Task<IResult> CreateOrder(IMediator mediator, CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var id = await mediator.SendCommandAsync<CreateOrderCommand, Order>(command, cancellationToken);
        return Results.Ok($"Order created : {id}");
    }

}
