using Domain.ValueObjects;

namespace Domain.Interfaces.Entities;

public interface IModifiedFoodItem : IFoodItem
{
    public List<Ingredient> AdditionalIngredients { get; init; }
    public void AddIngredient(Ingredient ingredient);
    public void RemoveIngredient(Ingredient ingredient);
}