using Domain.Entities;

namespace Domain.Interfaces.Entities;

public interface IModifiedFoodItem : IFoodItem
{
    public IReadOnlyList<Ingredient> AdditionalIngredients { get; init; }
    public void AddIngredient(Ingredient ingredient);
    public void RemoveIngredient(Ingredient ingredient);
}