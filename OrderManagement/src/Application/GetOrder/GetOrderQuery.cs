using Cortex.Mediator.Queries;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.GetOrder;
public class GetOrderQuery : IQuery<Order>
{
    public long OrderId { get; set; }
}
