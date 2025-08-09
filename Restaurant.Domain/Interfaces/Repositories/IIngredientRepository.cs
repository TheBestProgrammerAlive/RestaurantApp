using Domain.ValueObjects;

namespace Domain.Interfaces.Repositories;

public interface IIngredientRepository
{
    Task<IReadOnlyList<Ingredient>> GetAllIngredientsAsync();
    Task<Ingredient> GetIngredientByNameAsync(string name);
}