using MediatR;
using Restaurant.Application.Common.Dtos;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Common.Mapping;
using Restaurant.Application.Features.MenuManagement.Commands.CreateMenuItem;
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
        var dto = result.ToDto();
        return Results.Ok(dto);
    }

    private static async Task<IResult> GetMenuItemHandler(IMediator mediator, Guid itemId)
    {
        try
        {
            var menuItem = await mediator.Send(new GetMenuItemQuery(itemId));
            var dto = menuItem.ToDto();
            return Results.Ok(dto);
        }
        catch (NotFoundException)
        {
            return Results.StatusCode(StatusCodes.Status404NotFound);
        }
    }

    private static async Task<IResult> PostMenuItemHandler(IMediator mediator, MenuItemDto request)
    {
        var ingredients = request.DefaultIngredients?.ToEntities() ?? new();
        var command = new CreateMenuItemCommand(request.Name, request.BasePrice, ingredients);
        
            var createdId = await mediator.Send(command);
            var location = $"/menu-items/{createdId}";
            return Results.Created(location, new { id = createdId });
    }

}

