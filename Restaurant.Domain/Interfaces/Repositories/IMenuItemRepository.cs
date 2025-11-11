using Domain.Entities;

namespace Domain.Interfaces.Repositories;

/// <summary>
/// Repository for managing the restaurant's menu catalog (MenuItem entities).
/// Only deals with the master menu data, not order-specific customizations.
/// </summary>
public interface IMenuItemRepository
{
    Task<List<MenuItem>> GetAllMenuItemsAsync(CancellationToken cancellationToken = default);
    Task<MenuItem?> GetMenuItemByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddMenuItemAsync(MenuItem menuItem, CancellationToken cancellationToken = default);
    Task RemoveMenuItemAsync(MenuItem menuItem);
    Task UpdateMenuItemAsync(MenuItem menuItem);
}