using Domain.Entities;

namespace Domain.Interfaces.Repositories;

/// <summary>
/// Repository for managing the restaurant's menu catalog (MenuItem entities).
/// Only deals with the master menu data, not order-specific customizations.
/// </summary>
public interface IMenuItemRepository
{
    Task<List<MenuItem>> GetAllMenuItemsAsync();
    Task<MenuItem?> GetMenuItemByIdAsync(Guid id);
    Task AddMenuItemAsync(MenuItem menuItem);
    Task RemoveMenuItemAsync(MenuItem menuItem);
    Task UpdateMenuItemAsync(MenuItem menuItem);
}