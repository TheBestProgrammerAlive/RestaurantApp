using Domain.Interfaces;
using MediatR;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetMenuItem;

internal sealed class GetMenuItemHandler(IRestaurantRepository restaurantRepository)
    : IRequestHandler<GetMenuItemQuery, IFoodItem?>
{
    public Task<IFoodItem?> Handle(GetMenuItemQuery request, CancellationToken cancellationToken)
    {
        var result = restaurantRepository.GetMenuItemById(request.menuItemId);
        return Task.FromResult(result);
    }
}