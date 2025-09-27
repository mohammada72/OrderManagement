using OrderManagement.Infrastructure;
using OrderManagement.ServiceDefaults;
using OrderManagement.Web.Infrastructure;
using OrderManagement.Application;
using OrderManagement.Web;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.AddInfrastructureServices();
builder.AddWebServices();

app.MapDefaultEndpoints();
app.MapEndpoints();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.Run();
