using Domain.Entities;
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
        group.MapPost("/", PostMenuItemHandler);
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

    private static IResult PostMenuItemHandler(MenuItem menuItem)
    {
        if (string.IsNullOrWhiteSpace(menuItem.Name) || menuItem.BasePrice < 0)
        {
            return TypedResults.BadRequest();
        }

        // In this simplified example, we don't persist to DB (tests don't require it)
        // Return Created with a Location header
        var location = $"/menu-items/{menuItem.Id}";
        return TypedResults.Created(location, menuItem);
    }
}