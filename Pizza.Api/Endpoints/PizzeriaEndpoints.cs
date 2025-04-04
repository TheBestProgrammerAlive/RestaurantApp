namespace Pizza.Api.Endpoints;

public static class PizzeriaEndpoints
{
    public static void MapPizzeriaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/menuItems");

        group.MapGet("", async (context) => await Task.FromResult("yolo"));
    }
}