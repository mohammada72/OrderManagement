using Cortex.Mediator.Commands;

namespace OrderManagement.Application.CancelOrder;
public record CancelOrderCommand : ICommand<int>
{
    public long OrderId { get; set; }
}
