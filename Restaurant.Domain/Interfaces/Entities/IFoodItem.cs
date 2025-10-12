using Domain.Entities;

namespace Domain.Interfaces.Entities;

public interface IFoodItem
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public ICollection<Ingredient> Ingredients { get; }
}