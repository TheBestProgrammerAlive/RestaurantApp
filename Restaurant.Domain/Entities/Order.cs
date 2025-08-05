using Domain.Interfaces.Entities;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Order : IOrder
{
    private readonly List<IModifiedFoodItem> _items = new();

    public void AddMenuItem(IFoodItem foodItem)
    {
        if (foodItem is not IModifiedFoodItem)
        {
            var modifiedMenuItem = new ModifiedMenuItem(foodItem);
            this._items.Add(modifiedMenuItem);
        }
        else if (foodItem is IModifiedFoodItem modifiedFoodItem)
        {
            this._items.Add(modifiedFoodItem);
        }
    }

    public IReadOnlyList<IModifiedFoodItem> Items => _items.AsReadOnly();

    public void RemoveMenuItem(IModifiedFoodItem menuItem)
    {
        if (!_items.Remove(menuItem))
        {
            throw new InvalidOperationException("Cannot remove menu item from order, it's not present in the order.");
        }
    }

    public void AddAdditionalIngredients(Guid menuItemId, Ingredient additionalIngredient)
    {
        var foodItem = Items.FirstOrDefault(item => item.Id == menuItemId) ??
                       throw new InvalidOperationException("Menu item not found.");
        foodItem.AddIngredient(additionalIngredient);
    }

    public void RemoveAdditionalIngredient(Guid menuItemId, Ingredient ingredientToRemove)
    {
        var foodItem = Items.FirstOrDefault(item => item.Id == menuItemId) ??
                       throw new InvalidOperationException("Menu item not found.");
        foodItem.RemoveIngredient(ingredientToRemove);
    }
}