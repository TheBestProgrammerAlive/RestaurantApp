using Domain.ValueObjects;

namespace Domain.Interfaces.Entities;

public interface IFoodItem
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public IReadOnlyList<Ingredient> Ingredients { get; }
}