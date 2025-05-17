namespace Restaurant.Api.Endpoints;

public static class RestaurantEndpoints
{
    public static void MapRestaurantEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/menuItems");

        group.MapGet("", async (context) => await Task.FromResult("yolo"));
    }
}