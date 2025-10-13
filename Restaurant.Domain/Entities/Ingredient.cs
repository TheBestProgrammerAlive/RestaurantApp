namespace Domain.Entities;

public class Ingredient(Guid Id, string Name, decimal Price)
{
    public Guid Id { get; private set; } = Id;
    public string Name { get; private set; } = Name;
    public decimal Price { get; private set; } = Price;

    public Ingredient(string Name, decimal Price) : this(Guid.NewGuid(), Name, Price)
    {
    }

    private Ingredient() : this(Guid.Empty, String.Empty, Decimal.Zero)
    {
    }
}