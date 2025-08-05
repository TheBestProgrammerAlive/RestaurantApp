using Domain.Interfaces.Entities;

namespace Domain.Interfaces.Repositories;

public interface IMenuRepository
{
    Task<IFoodItem[]> GetAllMenuItemsAsync();
    Task<IFoodItem?> GetMenuItemByIdAsync(Guid id);
    Task AddMenuItemAsync(IFoodItem menuItem);
    Task RemoveMenuItemAsync(IFoodItem menuItem);
    Task UpdateMenuItemAsync(IFoodItem menuItem);
    Task SaveChangesAsync();
}