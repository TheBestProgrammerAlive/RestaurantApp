using Domain.Entities;
using MediatR;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetMenuItem;

public sealed record GetMenuItemQuery(Guid MenuItemId) : IRequest<MenuItem>;