using Cortex.Mediator.Commands;
using OrderManagement.Application.Common.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.CreateOrder;

public class CreateOrderCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateOrderCommand, Order>
{
    public async Task<Order> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = Order.Create(command.CustomerId);
        foreach (var item in command.OrderItems)
        {
            order.AddItem(item.ProductId, item.Quantity, item.UnitPrice);
        }

        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync(cancellationToken);
        return order;
    }
}
