using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastructure.Data.Contexts;

namespace Restaurant.Infrastructure.Data.Repositories;

/// <summary>
/// Repository for managing the restaurant's menu catalog.
/// Handles persistence of MenuItem entities (the master menu data).
/// </summary>
public class MenuItemRepository(RestaurantContext db) : IMenuItemRepository
{
    public async Task<List<MenuItem>> GetAllMenuItemsAsync( CancellationToken cancellationToken = default)
    {
        return await db.MenuItems.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<MenuItem?> GetMenuItemByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await db.MenuItems.FindAsync(id, cancellationToken);
    }

    public async Task AddMenuItemAsync(MenuItem menuItem, CancellationToken cancellationToken = default)
    {
        await db.MenuItems.AddAsync(menuItem, cancellationToken);
    }

    public Task RemoveMenuItemAsync(MenuItem menuItem)
    {
        db.MenuItems.Remove(menuItem);
        return Task.CompletedTask;
    }

    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
        db.MenuItems.Update(menuItem);
        await Task.CompletedTask;
    }
}