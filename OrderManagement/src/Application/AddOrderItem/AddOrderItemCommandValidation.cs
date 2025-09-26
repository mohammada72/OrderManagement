using FluentValidation;

namespace OrderManagement.Application.AddOrderItem;
public class AddOrderItemCommandValidation : AbstractValidator<AddOrderItemCommand>
{
    public AddOrderItemCommandValidation()
    {
        RuleFor(x => x.ProductId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
    }
}
