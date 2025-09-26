using OrderManagement.Domain.ValueObjects;

namespace OrderManagement.Domain.Entities;

public sealed class Customer
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Email Email { get; set; } = string.Empty;

    internal Customer() { }
    public static Customer Create(string name, string email)
    {
        var customer = new Customer()
        {
            Name = name,
            Email = email
        };
        return customer;
    }
}
