using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace OrderManagement.Web;
public static class DependencyInjection
{
    public static void AddWebServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddHttpContextAccessor();

        builder.Services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddOpenApiDocument((configure, sp) => configure.Title = "OrderManagement API");

        var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        builder.Services.AddSerilog(logger);
    }

}
