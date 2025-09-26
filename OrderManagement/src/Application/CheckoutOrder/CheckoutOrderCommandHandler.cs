using Cortex.Mediator.Commands;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Common.Interfaces;
using OrderManagement.Domain.Exceptions;

namespace OrderManagement.Application.CheckoutOrder;
public class CheckoutOrderCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<CheckoutOrderCommand, int>
{
    public async Task<int> Handle(CheckoutOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == command.OrderId)
            ?? throw new ItemNotFoundException(nameof(command.OrderId), "Order not found");
        order.Checkout();
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
