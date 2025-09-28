using Cortex.Mediator.Commands;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Common.Interfaces;
using OrderManagement.Domain.Exceptions;

namespace OrderManagement.Application.CancelOrder;
public class CancelOrderCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<CancelOrderCommand, int>
{
    public async Task<int> Handle(CancelOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == command.OrderId, cancellationToken: cancellationToken)
            ?? throw new ItemNotFoundException(nameof(command.OrderId), "Order not found");
        order.Cancel();
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
