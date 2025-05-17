using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IFoodItem
{
    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public IReadOnlyList<Ingredient> Ingredients { get; }
}