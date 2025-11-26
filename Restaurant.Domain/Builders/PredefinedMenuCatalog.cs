using Domain.Entities;

namespace Domain.Builders;

/// <summary>
/// Canonical, single source of truth for predefined Ingredients and MenuItems
/// used by both application seeding and tests.
/// </summary>
public static class PredefinedMenuCatalog
{
    /// <summary>
    /// Predefined ingredients with stable IDs/prices.
    /// </summary>
    public static IReadOnlyList<Ingredient> Ingredients { get; } = new List<Ingredient>
    {
        new(Guid.Parse("11111111-1111-1111-1111-111111111111"), "Tomato Sauce", 0.50m),
        new(Guid.Parse("22222222-2222-2222-2222-222222222222"), "Mozzarella Cheese", 1.20m),
        new(Guid.Parse("33333333-3333-3333-3333-333333333333"), "Pepperoni", 1.80m),
        new(Guid.Parse("44444444-4444-4444-4444-444444444444"), "Ham", 1.50m),
        new(Guid.Parse("55555555-5555-5555-5555-555555555555"), "Pineapple", 1.00m),
        new(Guid.Parse("66666666-6666-6666-6666-666666666666"), "Basil", 0.40m),
        new(Guid.Parse("77777777-7777-7777-7777-777777777777"), "Extra Cheese", 1.00m)
    };

    /// <summary>
    /// Build the canonical set of menu items using the provided ingredient instances.
    /// The IDs/names/prices match tests and seeding expectations.
    /// </summary>
    public static IReadOnlyList<MenuItem> BuildMenuItemsFrom(IEnumerable<Ingredient> ingredients)
    {
        Ingredient Find(string name) => ingredients.First(i => i.Name == name);

        return new List<MenuItem>
        {
            new(
                Guid.Parse("f1a2b3c4-d5e6-4789-abcd-0123456789ab"),
                "Margherita",
                7.99m,
                new List<Ingredient>
                {
                    Find("Tomato Sauce"),
                    Find("Mozzarella Cheese"),
                    Find("Basil")
                }
            ),
            new(
                Guid.Parse("d5e6f7a8-b9c0-4d1e-8f2a-123456789abc"),
                "Pepperoni",
                9.99m,
                new List<Ingredient>
                {
                    Find("Tomato Sauce"),
                    Find("Mozzarella Cheese"),
                    Find("Pepperoni")
                }
            ),
            new(
                Guid.Parse("9a8b7c6d-5e4f-3a2b-1c0d-abcdef123456"),
                "Hawaiian",
                10.99m,
                new List<Ingredient>
                {
                    Find("Tomato Sauce"),
                    Find("Mozzarella Cheese"),
                    Find("Ham"),
                    Find("Pineapple")
                }
            )
        };
    }
}
