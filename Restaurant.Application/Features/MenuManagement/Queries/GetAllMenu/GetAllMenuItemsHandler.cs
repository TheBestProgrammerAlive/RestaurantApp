using Domain.Interfaces.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetAllMenu;

internal sealed class GetAllMenuItemsHandler(IMenuRepository menuRepository)
    : IRequestHandler<GetAllMenuItemsQuery, IFoodItem[]>
{
    public async Task<IFoodItem[]> Handle(GetAllMenuItemsQuery _, CancellationToken cancellationToken)
    {
        var result = await menuRepository.GetAllMenuItemsAsync();
        return result;
    }
}