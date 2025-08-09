using Domain.Interfaces.Repositories;
using Domain.ValueObjects;

namespace Restaurant.Infrastructure.Data.Repositories;

public class IngredientRepository : IIngredientRepository
{
    public Task<IReadOnlyList<Ingredient>> GetAllIngredientsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Ingredient> GetIngredientByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}