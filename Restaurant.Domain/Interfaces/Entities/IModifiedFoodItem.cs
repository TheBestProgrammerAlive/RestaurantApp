using Domain.Entities;

namespace Domain.Interfaces.Entities;

public interface IModifiedFoodItem : IFoodItem
{
    public IReadOnlyList<Ingredient> AdditionalIngredients { get; }
    public void AddIngredient(Ingredient ingredient);
    public void RemoveIngredient(Ingredient ingredient);
}