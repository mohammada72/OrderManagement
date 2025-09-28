using Cortex.Mediator.Commands;
using OrderManagement.Application.AddOrderItem;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.CreateOrder;
public class CreateOrderCommand : ICommand<Order>
{
    public long CustomerId { get; set; }
    public required List<AddOrderItemCommand> OrderItems { get; set; }

}
