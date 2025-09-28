using OrderManagement.Domain.ValueObjects;

namespace OrderManagement.Domain.Entities;

public sealed class Customer
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Email Email { get; set; } = new("w@w.com");

    internal Customer() { }
    public static Customer Create(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (name.Length > 500) throw new ArgumentOutOfRangeException(nameof(name));

        var customer = new Customer()
        {
            Name = name,
            Email = email
        };
        return customer;
    }
}
