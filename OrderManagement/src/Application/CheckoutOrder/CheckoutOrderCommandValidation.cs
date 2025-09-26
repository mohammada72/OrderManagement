using FluentValidation;

namespace OrderManagement.Application.CheckoutOrder;
public class CheckoutOrderCommandValidation : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidation()
    {
        RuleFor(x => x.OrderId).NotEmpty().GreaterThan(0);
    }
}
