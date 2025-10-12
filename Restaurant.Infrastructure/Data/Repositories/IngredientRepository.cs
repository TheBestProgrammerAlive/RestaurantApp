using Domain.Entities;
using Domain.Interfaces.Repositories;

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