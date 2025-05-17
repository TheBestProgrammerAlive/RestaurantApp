using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities;

public class ModifiedMenuItem(
    Guid id,
    string name,
    decimal price,
    IReadOnlyList<Ingredient> ingredients,
    List<Ingredient> additionalIngredients) : BaseMenuItem(id, name, price, ingredients), IModifiedFoodItem
{
    public List<Ingredient> AdditionalIngredients { get; } = additionalIngredients;


    public ModifiedMenuItem() : this(Guid.Empty, string.Empty, decimal.Zero, Array.Empty<Ingredient>(),
        new List<Ingredient>())
    {
    }

    public ModifiedMenuItem(IFoodItem foodItem) : this(Guid.NewGuid(), foodItem.Name, foodItem.Price,
        foodItem.Ingredients, new List<Ingredient>())
    {
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if (AdditionalIngredients.Count >= Consts.MaxAdditionalIngredients)
        {
            throw new InvalidOperationException("Item cannot have more than " + Consts.MaxAdditionalIngredients +
                                                " additional ingredients.");
        }

        if (!Menu.TryFindIngredient(ingredient.Name, out _))
        {
            throw new ArgumentException("Ingredient not available.");
        }

        AdditionalIngredients.Add(ingredient);
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        if (!AdditionalIngredients.Any())
        {
            throw new InvalidOperationException("No additional ingredients in item");
        }

        if (!Menu.TryFindIngredient(ingredient.Name, out _))
        {
            throw new ArgumentException("Ingredient not available.");
        }

        AdditionalIngredients.Remove(ingredient);
    }
}