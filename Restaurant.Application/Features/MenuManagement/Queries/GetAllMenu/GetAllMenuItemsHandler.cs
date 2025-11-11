using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetAllMenu;

internal sealed class GetAllMenuItemsHandler(IMenuItemRepository menuItemRepository)
    : IRequestHandler<GetAllMenuItemsQuery, List<MenuItem>>
{
    public async Task<List<MenuItem>> Handle(GetAllMenuItemsQuery _, CancellationToken cancellationToken)
    {
        var result = await menuItemRepository.GetAllMenuItemsAsync(cancellationToken);
        return result;
    }
}