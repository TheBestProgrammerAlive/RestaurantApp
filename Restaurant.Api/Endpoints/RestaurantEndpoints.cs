using Domain.Entities;

namespace Restaurant.Api.Endpoints;

public static class RestaurantEndpoints
{
    public static void MapRestaurantEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/menu-items");

        group.MapGet("/", () => Menu.AvailableBaseMenuItems);
        group.MapGet("{itemId:guid}", GetMenuItemHandler);
    }

    private static IResult GetMenuItemHandler(Guid itemId)
    {
        if (Menu.TryFindMenuItem(itemId, out var menuItem))
        {
            return Results.Ok(menuItem);
        }

        return Results.NotFound();
    }
}