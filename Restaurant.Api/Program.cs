using Restaurant.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddJsonConsole();

var app = builder.Build();
app.MapRestaurantEndpoints();

app.Run();

public partial class Program
{
}