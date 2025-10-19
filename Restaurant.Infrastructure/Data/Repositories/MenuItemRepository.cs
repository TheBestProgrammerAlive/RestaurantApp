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
    public async Task<List<MenuItem>> GetAllMenuItemsAsync()
    {
        return await db.MenuItems.AsNoTracking().ToListAsync();
    }

    public async Task<MenuItem?> GetMenuItemByIdAsync(Guid id)
    {
        return await db.MenuItems.FindAsync(id);
    }

    public Task AddMenuItemAsync(MenuItem menuItem)
    {
        db.MenuItems.Add(menuItem);
        return Task.CompletedTask;
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