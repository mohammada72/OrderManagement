using Cortex.Mediator.Queries;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Common.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Exceptions;

namespace OrderManagement.Application.GetOrder;
public class GetOrderQueryHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrderQuery, Order>
{
    public async Task<Order> Handle(GetOrderQuery query, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == query.OrderId, cancellationToken)
                        ?? throw new ItemNotFoundException(query.OrderId.ToString(), "Order");

        return order;
    }
}
