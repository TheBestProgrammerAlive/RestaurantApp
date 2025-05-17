using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IOrder
{
    void AddMenuItem(IFoodItem foodItem);
    IReadOnlyList<IModifiedFoodItem> Items { get; }
    void RemoveMenuItem(IModifiedFoodItem menuItem);
    void AddAdditionalIngredients(Guid menuItemId, Ingredient additionalIngredient);
    void RemoveAdditionalIngredient(Guid menuItemId, Ingredient ingredientToRemove);
}