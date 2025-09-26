using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OrderManagement.Application.GetOrder;
public class GetOrderQueryValidation : AbstractValidator<GetOrderQuery>
{
    public GetOrderQueryValidation()
    {
        RuleFor(x => x.OrderId).NotEmpty().GreaterThan(0);
    }
}
