using Domain.Interfaces;
using MediatR;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetAllMenu;

public sealed record GetAllMenuItemsQuery() : IRequest<IFoodItem[]>;