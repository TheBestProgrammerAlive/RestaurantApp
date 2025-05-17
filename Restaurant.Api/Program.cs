using Restaurant.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();
app.MapRestaurantEndpoints();

app.Run();