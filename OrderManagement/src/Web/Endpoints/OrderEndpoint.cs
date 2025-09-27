using Cortex.Mediator;
using OrderManagement.Application.AddOrderItem;
using OrderManagement.Application.CheckoutOrder;
using OrderManagement.Application.CreateOrder;
using OrderManagement.Application.GetOrder;
using OrderManagement.Domain.Entities;
using OrderManagement.Web.Infrastructure;

namespace OrderManagement.Web.Endpoints;
public class OrderEndpoint : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("/", CreateOrder).WithName(nameof(CreateOrder));
        groupBuilder.MapPost("/AddItem", AddOrderItem).WithName(nameof(AddOrderItem));
        groupBuilder.MapPost("/Checkout", Checkout).WithName(nameof(AddOrderItem));
        groupBuilder.MapGet("/{id}", GetById).WithName(nameof(AddOrderItem));
    }

    public async Task<IResult> CreateOrder(IMediator mediator, CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await mediator.SendCommandAsync<CreateOrderCommand, Order>(command, cancellationToken);
        return Results.Ok(order);
    }

    public async Task<IResult> AddOrderItem(IMediator mediator, AddOrderItemCommand command, CancellationToken cancellationToken)
    {
        var order = await mediator.SendCommandAsync<AddOrderItemCommand, Order>(command, cancellationToken);
        return Results.Ok(order);
    }

    public async Task<IResult> Checkout(IMediator mediator, CheckoutOrderCommand command, CancellationToken cancellationToken)
    {
        await mediator.SendCommandAsync<CheckoutOrderCommand, int>(command, cancellationToken);
        return Results.Ok("Order checked out");
    }
    public async Task<IResult> GetById(IMediator mediator, long id, CancellationToken cancellationToken)
    {
        var order = await mediator.SendQueryAsync<GetOrderQuery, Order>(new() { OrderId = id }, cancellationToken);
        return Results.Ok(order);
    }
}
