using Restaurant.Api.Endpoints;
using Restaurant.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddJsonConsole();
builder.Services.AddApplication();
var app = builder.Build();
app.MapRestaurantEndpoints();

app.Run();

public partial class Program
{
}