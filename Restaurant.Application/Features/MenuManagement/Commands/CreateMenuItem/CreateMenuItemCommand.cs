using Domain.Entities;
using MediatR;

namespace Restaurant.Application.Features.MenuManagement.Commands.CreateMenuItem;

public sealed record CreateMenuItemCommand(string Name, decimal RequestBasePrice, List<Ingredient> DefaultIngredients) : IRequest<Guid>;