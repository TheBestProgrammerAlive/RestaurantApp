using Domain.Interfaces;
using MediatR;

namespace Restaurant.Application.Queries;

public sealed class GetAllMenuItemsHandler(IRestaurantRepository restaurantRepository)
    : IRequestHandler<GetAllMenuItemsQuery, IFoodItem[]>
{
    public Task<IFoodItem[]> Handle(GetAllMenuItemsQuery _, CancellationToken cancellationToken)
    {
        var result = restaurantRepository.GetAllMenuItems();
        return Task.FromResult(result);
    }
}