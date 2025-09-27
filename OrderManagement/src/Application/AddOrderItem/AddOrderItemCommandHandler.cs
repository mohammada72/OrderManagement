using Cortex.Mediator.Commands;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Common.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Exceptions;

namespace OrderManagement.Application.AddOrderItem;
public class AddOrderItemCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<AddOrderItemCommand, Order>
{
    public async Task<Order> Handle(AddOrderItemCommand command, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == command.OrderId)
            ?? throw new ItemNotFoundException(nameof(command.OrderId), "Order not found");
        order.AddItem(command.ProductId, command.Quantity, command.UnitPrice);
        await dbContext.SaveChangesAsync(cancellationToken);
        return order;
    }
}
