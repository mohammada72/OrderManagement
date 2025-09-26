using Cortex.Mediator.Commands;
using OrderManagement.Application.Common.Interfaces;
using OrderManagement.Domain.Entities;

namespace Application.CreateCustomer;

public class CreateCustomerCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateCustomerCommand, Customer>
{
    public async Task<Customer> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Name = command.Name,
            Email = command.Email,
        };
        dbContext.Customers.Add(customer);
        await dbContext.SaveChangesAsync(cancellationToken);
        return customer;
    }
}
