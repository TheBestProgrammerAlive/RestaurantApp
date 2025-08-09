using Domain.Interfaces.Repositories;
using Restaurant.Infrastructure.Data.Contexts;

namespace Restaurant.Infrastructure.Data.UnitsOfWork;

public sealed class EfUnitOfWork(
    RestaurantContext db,
    IMenuItemRepository menuItems,
    IIngredientRepository ingredients) : IUnitOfWork
{
    public IMenuItemRepository MenuItems { get; } = menuItems;
    public IIngredientRepository Ingredients { get; } = ingredients;
    public Task<int> SaveChangesAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);
}