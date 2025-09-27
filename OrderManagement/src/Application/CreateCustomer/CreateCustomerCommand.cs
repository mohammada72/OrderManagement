using Cortex.Mediator.Commands;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.CreateCustomer;

public class CreateCustomerCommand : ICommand<Customer>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
