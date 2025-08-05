using MediatR;
using Restaurant.Application.Features.MenuManagement.Queries.GetAllMenu;
using Restaurant.Application.Features.MenuManagement.Queries.GetMenuItem;

namespace Restaurant.Api.Endpoints;

public static class RestaurantEndpoints
{
    public static void MapRestaurantEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/menu-items");

        group.MapGet("/", GetMenuItemsHandler);
        group.MapGet("{itemId:guid}", GetMenuItemHandler);
    }

    private static async Task<IResult> GetMenuItemsHandler(IMediator mediator)
    {
        var result = await mediator.Send(new GetAllMenuItemsQuery());
        return TypedResults.Ok(result);
    }

    private static async Task<IResult> GetMenuItemHandler(IMediator mediator, Guid itemId)
    {
        var menuItem = await mediator.Send(new GetMenuItemQuery(itemId));
        return TypedResults.Ok(menuItem);
    }
}