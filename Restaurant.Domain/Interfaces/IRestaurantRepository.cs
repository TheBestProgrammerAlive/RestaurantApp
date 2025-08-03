using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IRestaurantRepository
{
    IFoodItem[] GetAllMenuItems();
    IFoodItem GetMenuItemById(Guid id);
    void AddMenuItem(IFoodItem menuItem);
    void RemoveMenuItem(IFoodItem menuItem);
    void UpdateMenuItem(IFoodItem menuItem);
    Ingredient[] GetAllIngredients();
    Ingredient GetIngredientByName(string name);

    void SaveChanges();
}