using Cortex.Mediator.Commands;

namespace OrderManagement.Application.CheckoutOrder;
public record CheckoutOrderCommand : ICommand<int>
{
    public long OrderId { get; set; }
}
