namespace Domain.Entities;

/// <summary>
/// Represents a customized menu item within an order (NOT stored separately in DB).
/// Part of the Order aggregate - contains customer's modifications to a base MenuItem.
/// </summary>
public class OrderItem
{
    public Guid Id { get; private set; }
    public MenuItem BaseMenuItem { get; private set; }
    private readonly List<Ingredient> _addedIngredients = new();
    private readonly List<Ingredient> _removedIngredients = new();

    public IReadOnlyList<Ingredient> AddedIngredients => _addedIngredients.AsReadOnly();
    public IReadOnlyList<Ingredient> RemovedIngredients => _removedIngredients.AsReadOnly();

    public OrderItem(MenuItem baseMenuItem)
    {
        Id = Guid.NewGuid();
        BaseMenuItem = baseMenuItem ?? throw new ArgumentNullException(nameof(baseMenuItem));
    }

    // Parameterless constructor for EF Core
    private OrderItem()
    {
        BaseMenuItem = null!;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredient == null)
            throw new ArgumentNullException(nameof(ingredient));

        if (_addedIngredients.Count >= Consts.MaxAdditionalIngredients)
        {
            throw new InvalidOperationException($"Item cannot have more than {Consts.MaxAdditionalIngredients} additional ingredients.");
        }

        if (!Menu.TryFindIngredient(ingredient.Name, out _))
        {
            throw new ArgumentException("Ingredient not available.", nameof(ingredient));
        }

        if (!_addedIngredients.Contains(ingredient))
            _addedIngredients.Add(ingredient);
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        if (ingredient == null)
            throw new ArgumentNullException(nameof(ingredient));

        if (!BaseMenuItem.DefaultIngredients.Any(i => i.Name == ingredient.Name))
        {
            throw new InvalidOperationException("Cannot remove ingredient that's not in the base item.");
        }

        if (!Menu.TryFindIngredient(ingredient.Name, out _))
        {
            throw new ArgumentException("Ingredient not available.", nameof(ingredient));
        }

        if (!_removedIngredients.Contains(ingredient))
            _removedIngredients.Add(ingredient);
    }
    public decimal CalculatePrice()
    {
        var addedCost = _addedIngredients.Sum(i => i.Price);
        var removedDiscount = _removedIngredients.Sum(i => i.Price * 0.5m);
        return BaseMenuItem.BasePrice + addedCost - removedDiscount;
    }
}