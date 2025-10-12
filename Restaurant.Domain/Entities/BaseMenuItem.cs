using Domain.Interfaces.Entities;

namespace Domain.Entities;

public class BaseMenuItem(Guid id, string name, decimal price, ICollection<Ingredient> ingredients) : IFoodItem
{
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name;
    public decimal Price { get; init; } = price;

    public ICollection<Ingredient> Ingredients { get; init; } = ingredients;

    public BaseMenuItem() : this(Guid.Empty, string.Empty, decimal.Zero, Array.Empty<Ingredient>())
    {
    }
}