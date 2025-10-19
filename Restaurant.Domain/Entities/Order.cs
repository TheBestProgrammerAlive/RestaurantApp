namespace Domain.Entities;

/// <summary>
/// Order aggregate root containing OrderItems with their customizations.
/// </summary>
public class Order
{
    private readonly List<OrderItem> _items = new();

    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Adds a menu item from the catalog to the order.
    /// Creates an OrderItem that references the catalog MenuItem.
    /// </summary>
    public void AddItem(MenuItem menuItem)
    {
        if (menuItem == null)
            throw new ArgumentNullException(nameof(menuItem));

        var orderItem = new OrderItem(menuItem);
        _items.Add(orderItem);
    }

    /// <summary>
    /// Removes an order item from the order.
    /// </summary>
    public void RemoveItem(OrderItem orderItem)
    {
        if (orderItem == null)
            throw new ArgumentNullException(nameof(orderItem));

        if (!_items.Remove(orderItem))
        {
            throw new InvalidOperationException("Cannot remove order item, it's not present in the order.");
        }
    }
    
    /// <summary>
    /// Adds an ingredient to a specific order item.
    /// </summary>
    public void AddIngredientToItem(Guid orderItemId, Ingredient ingredient)
    {
        var orderItem = Items.FirstOrDefault(item => item.Id == orderItemId) ??
                        throw new InvalidOperationException("Order item not found.");
        orderItem.AddIngredient(ingredient);
    }

    /// <summary>
    /// Removes an ingredient from a specific order item.
    /// </summary>
    public void RemoveIngredientFromItem(Guid orderItemId, Ingredient ingredient)
    {
        var orderItem = Items.FirstOrDefault(item => item.Id == orderItemId) ??
                        throw new InvalidOperationException("Order item not found.");
        orderItem.RemoveIngredient(ingredient);
    }

    /// <summary>
    /// Calculates the total price of the order including all customizations.
    /// </summary>
    public decimal CalculateTotal() => _items.Sum(i => i.CalculatePrice());
}