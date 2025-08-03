using Domain.Interfaces;
using MediatR;

namespace Restaurant.Application.Queries;

public sealed record GetAllMenuItemsQuery() : IRequest<IFoodItem[]>;