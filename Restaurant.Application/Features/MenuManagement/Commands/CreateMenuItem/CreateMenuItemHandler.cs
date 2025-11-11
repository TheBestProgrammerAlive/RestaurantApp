using Domain.Entities;
using MediatR;
using Restaurant.Infrastructure.Data.UnitsOfWork;

namespace Restaurant.Application.Features.MenuManagement.Commands.CreateMenuItem;

internal sealed class CreateMenuItemHandler(EfUnitOfWork uow): IRequestHandler<CreateMenuItemCommand, Guid>
{
    public async Task<Guid> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menuItem = new MenuItem(request.Name, request.RequestBasePrice, request.DefaultIngredients);
        await uow.MenuItems.AddMenuItemAsync(menuItem, cancellationToken);
        await uow.SaveChangesAsync(cancellationToken);
        return menuItem.Id;
    }
}