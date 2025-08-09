using Domain.Interfaces.Entities;
using MediatR;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetAllMenu;

public sealed record GetAllMenuItemsQuery() : IRequest<List<IFoodItem>>;