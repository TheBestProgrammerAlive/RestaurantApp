using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Restaurant.Application.Common.Exceptions;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetMenuItem;

internal sealed class GetMenuItemHandler(IMenuItemRepository menuItemRepository)
    : IRequestHandler<GetMenuItemQuery, MenuItem>
{
    public async Task<MenuItem> Handle(GetMenuItemQuery request, CancellationToken cancellationToken)
    {
        var result = await menuItemRepository.GetMenuItemByIdAsync(request.MenuItemId, cancellationToken);
        if (result is null) throw new NotFoundException(nameof(MenuItem), request.MenuItemId);
        return result;
    }
}