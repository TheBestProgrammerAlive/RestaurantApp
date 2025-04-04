using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities;

public interface IModifiedFoodItem : IFoodItem
{
    public List<Ingredient> AdditionalIngredients { get; }
    public void AddIngredient(Ingredient ingredient);
    public void RemoveIngredient(Ingredient ingredient);
}