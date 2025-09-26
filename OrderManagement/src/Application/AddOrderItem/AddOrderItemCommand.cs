using Cortex.Mediator.Commands;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.AddOrderItem;
public record AddOrderItemCommand : ICommand<Order>
{
    public long OrderId { get; }
    public long ProductId { get; }
    public int Quantity { get; }
    public decimal UnitPrice { get; }
}
