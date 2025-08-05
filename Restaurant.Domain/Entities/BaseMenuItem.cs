using Domain.Interfaces.Entities;
using Domain.ValueObjects;

namespace Domain.Entities;

public class BaseMenuItem(Guid id, string name, decimal price, IReadOnlyList<Ingredient> ingredients) : IFoodItem
{
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name;
    public decimal Price { get; init; } = price;

    public IReadOnlyList<Ingredient> Ingredients { get; } = ingredients;

    public BaseMenuItem() : this(Guid.Empty, string.Empty, decimal.Zero, Array.Empty<Ingredient>())
    {
    }
}