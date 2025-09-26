using Cortex.Mediator.Behaviors;
using Cortex.Mediator.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderManagement.Application.Common.Behaviours;
using OrderManagement.Application.Services;

namespace OrderManagement.Application;
public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(DependencyInjection).Assembly));

        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddCortexMediator(builder.Configuration,
                            [typeof(DependencyInjection)],
                            options =>
                            {
                                options.AddDefaultBehaviors();
                                options.AddOpenCommandPipelineBehavior(typeof(UnhandledExceptionBehaviour<,>));
                                options.AddOpenCommandPipelineBehavior(typeof(PerformanceBehaviour<,>));

                                options.AddOpenQueryPipelineBehavior(typeof(UnhandledExceptionBehaviour<,>));
                                options.AddOpenQueryPipelineBehavior(typeof(PerformanceBehaviour<,>));
                            });

    }
}
