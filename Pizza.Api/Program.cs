using Pizza.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();
app.MapPizzeriaEndpoints();

app.Run();