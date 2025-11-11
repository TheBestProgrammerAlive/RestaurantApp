using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Domain.Entities;
using MediatR;
using Restaurant.Application.Common.Dtos;
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
        return Results.Ok(result);
    }

    private static async Task<IResult> GetMenuItemHandler(IMediator mediator, Guid itemId)
    {
        try
        {
            var menuItem = await mediator.Send(new GetMenuItemQuery(itemId));
            return Results.Ok(menuItem);
        }
        catch (Restaurant.Application.Common.Exceptions.NotFoundException)
        {
            return Results.StatusCode(StatusCodes.Status404NotFound);
        }
    }

    private static async Task<IResult> PostMenuItemHandler(IMediator mediator, MenuItemDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || request.BasePrice < 0)
            return Results.BadRequest();

        var command = new CreateMenuItemCommand(request.Name, request.BasePrice, request.DefaultIngredients);

        try
        {
            var createdId = await mediator.Send(command);
            var location = $"/menu-items/{createdId}";
            return Results.Created(location, new { id = createdId });
        }
        catch (ValidationException ex)
        {
            return Results.ValidationProblem();
        }
    }

}

