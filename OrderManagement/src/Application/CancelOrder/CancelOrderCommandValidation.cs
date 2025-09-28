using FluentValidation;

namespace OrderManagement.Application.CancelOrder;
public class CancelOrderCommandValidation : AbstractValidator<CancelOrderCommand>
{
    public CancelOrderCommandValidation()
    {
        RuleFor(x => x.OrderId).NotEmpty().GreaterThan(0);
    }
}
