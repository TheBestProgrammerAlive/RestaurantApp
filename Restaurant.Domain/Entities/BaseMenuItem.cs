using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities;

public class BaseMenuItem(Guid id, string name, decimal price, IReadOnlyList<Ingredient> ingredients) : IFoodItem
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;
    public decimal Price { get; } = price;

    public IReadOnlyList<Ingredient> Ingredients { get; } = ingredients;

    public BaseMenuItem() : this(Guid.Empty, string.Empty, decimal.Zero, Array.Empty<Ingredient>())
    {
    }
}