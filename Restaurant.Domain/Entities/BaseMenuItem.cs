namespace Domain.Entities;

/// <summary>
/// Represents a menu item in the restaurant's catalog (template/master data).
/// This is what's stored in the database as the available menu.
/// </summary>
public class MenuItem
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal BasePrice { get; private set; }
    public List<Ingredient> DefaultIngredients { get; private set; }

    public MenuItem(Guid id, string name, decimal basePrice, List<Ingredient> defaultIngredients)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
        if (basePrice < 0)
            throw new ArgumentException("Price cannot be negative", nameof(basePrice));

        Id = id;
        Name = name;
        BasePrice = basePrice;
        DefaultIngredients = defaultIngredients ?? new List<Ingredient>();
    }

    // Parameterless constructor for EF Core
    private MenuItem()
    {
        Name = string.Empty;
        DefaultIngredients = new List<Ingredient>();
    }
}