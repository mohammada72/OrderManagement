using FluentValidation;

namespace OrderManagement.Application.CreateOrder;
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.OrderItems).NotEmpty().Must(x => x.Count > 0);
    }
}

