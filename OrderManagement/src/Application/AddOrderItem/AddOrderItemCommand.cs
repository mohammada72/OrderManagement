using Cortex.Mediator.Commands;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.AddOrderItem;
public record AddOrderItemCommand : ICommand<Order>
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
