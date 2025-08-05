using Domain.ValueObjects;

namespace Domain.Interfaces.Repositories;

public interface IIngredientRepository
{
    Task<Ingredient[]> GetAllIngredientsAsync();
    Task<Ingredient> GetIngredientByNameAsync(string name);
    Task SaveChangesAsync();
}