using Domain.Interfaces.Entities;

namespace Domain.Interfaces.Repositories;

public interface IMenuItemRepository
{
    Task<List<IFoodItem>> GetAllMenuItemsAsync();
    Task<IFoodItem?> GetMenuItemByIdAsync(Guid id);
    Task AddMenuItemAsync(IFoodItem menuItem);
    Task RemoveMenuItemAsync(IFoodItem menuItem);
    Task UpdateMenuItemAsync(IFoodItem menuItem);
}