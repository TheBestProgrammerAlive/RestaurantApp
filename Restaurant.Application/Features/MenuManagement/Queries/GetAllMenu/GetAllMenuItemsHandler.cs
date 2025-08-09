using Domain.Interfaces.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetAllMenu;

internal sealed class GetAllMenuItemsHandler(IMenuItemRepository menuItemRepository)
    : IRequestHandler<GetAllMenuItemsQuery, List<IFoodItem>>
{
    public async Task<List<IFoodItem>> Handle(GetAllMenuItemsQuery _, CancellationToken cancellationToken)
    {
        var result = await menuItemRepository.GetAllMenuItemsAsync();
        return result;
    }
}