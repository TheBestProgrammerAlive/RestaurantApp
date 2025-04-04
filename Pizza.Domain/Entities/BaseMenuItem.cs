using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities;

public class BaseMenuItem(Guid id, string name, decimal price, IReadOnlyList<Ingredient> ingredients) : IFoodItem
{
    public Guid Id { get; protected init; } = id;
    public string Name { get; protected init; } = name;
    public decimal Price { get; protected init; } = price;

    public IReadOnlyList<Ingredient> Ingredients { get; init; } = ingredients;

    public BaseMenuItem() : this(Guid.Empty, string.Empty, decimal.Zero, Array.Empty<Ingredient>())
    {
    }
}