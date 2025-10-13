using Domain.Interfaces.Entities;

namespace Domain.Entities;

public class ModifiedMenuItem(
    Guid id,
    string name,
    decimal price,
    ICollection<Ingredient> ingredients,
    IEnumerable<Ingredient> additionalIngredients) : BaseMenuItem(id, name, price, ingredients), IModifiedFoodItem
{
    private readonly List<Ingredient> _additionalIngredients = additionalIngredients.ToList() ?? new();
    public IReadOnlyList<Ingredient> AdditionalIngredients => _additionalIngredients.AsReadOnly();


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
        if (_additionalIngredients.Count >= Consts.MaxAdditionalIngredients)
        {
            throw new InvalidOperationException("Item cannot have more than " + Consts.MaxAdditionalIngredients +
                                                " additional ingredients.");
        }

        if (!Menu.TryFindIngredient(ingredient.Name, out _))
        {
            throw new ArgumentException("Ingredient not available.");
        }

        _additionalIngredients.Add(ingredient);
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        if (!_additionalIngredients.Any())
        {
            throw new InvalidOperationException("No additional ingredients in item");
        }

        if (!Menu.TryFindIngredient(ingredient.Name, out _))
        {
            throw new ArgumentException("Ingredient not available.");
        }

        _additionalIngredients.Remove(ingredient);
    }
}