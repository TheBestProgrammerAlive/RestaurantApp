using Domain.Interfaces.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Restaurant.Application.Common.Exceptions;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetMenuItem;

internal sealed class GetMenuItemHandler(IMenuRepository menuRepository)
    : IRequestHandler<GetMenuItemQuery, IFoodItem>
{
    public async Task<IFoodItem> Handle(GetMenuItemQuery request, CancellationToken cancellationToken)
    {
        var result = await menuRepository.GetMenuItemByIdAsync
            (request.MenuItemId);
        if (result is null) throw new NotFoundException(nameof(IFoodItem), request.MenuItemId);
        return result;
    }
}