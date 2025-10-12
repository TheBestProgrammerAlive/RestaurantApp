namespace Domain.Entities;

public class Ingredient(Guid Id, string Name, decimal Price)
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; }

    private Ingredient() : this(Guid.Empty, String.Empty, Decimal.Zero)
    {
    }
}