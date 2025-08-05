using Restaurant.Api.Endpoints;
using Restaurant.Api.ExceptionHandling;
using Restaurant.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddJsonConsole();
builder.Services.AddApplication();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();
app.UseExceptionHandler();
app.MapRestaurantEndpoints();

app.Run();

namespace Restaurant.Api
{
    public partial class Program
    {
    }
}