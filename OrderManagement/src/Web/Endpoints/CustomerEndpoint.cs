using Cortex.Mediator;
using OrderManagement.Application.CreateCustomer;
using OrderManagement.Domain.Entities;
using OrderManagement.Web.Infrastructure;

namespace OrderManagement.Web.Endpoints;
public class CustomerEndpoint : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("/", CreateCustomer).WithName(nameof(CreateCustomer));
    }

    public async Task<IResult> CreateCustomer(IMediator mediator, CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = await mediator.SendCommandAsync<CreateCustomerCommand, Customer>(command, cancellationToken);
        return Results.Ok(customer);
    }

}
