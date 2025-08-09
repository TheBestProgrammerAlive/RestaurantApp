using Domain.Entities;
using Domain.Interfaces.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastructure.Data.Contexts;

namespace Restaurant.Infrastructure.Data.Repositories;

public class MenuItemRepository(RestaurantContext db) : IMenuItemRepository
{
    public async Task<List<IFoodItem>> GetAllMenuItemsAsync()
    {
        return await db.MenuItems.AsNoTracking().Cast<IFoodItem>().ToListAsync();
    }

    public async Task<IFoodItem?> GetMenuItemByIdAsync(Guid id)
    {
        return await db.MenuItems.FindAsync(id);
    }

    public Task AddMenuItemAsync(IFoodItem menuItem)
    {
        db.MenuItems.Add((BaseMenuItem)menuItem);
        return Task.CompletedTask;
    }

    public Task RemoveMenuItemAsync(IFoodItem menuItem)
    {
        db.MenuItems.Remove((BaseMenuItem)menuItem);
        return Task.CompletedTask;
    }

    public async Task UpdateMenuItemAsync(IFoodItem menuItem)
    {
        db.MenuItems.Update((BaseMenuItem)menuItem);
        await Task.CompletedTask;
    }
}