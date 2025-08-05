using Domain.Interfaces;
using MediatR;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetMenuItem;

public sealed record GetMenuItemQuery(Guid menuItemId) : IRequest<IFoodItem?>;