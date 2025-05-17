using Domain.ValueObjects;

namespace Domain.Entities;

public static class Menu
{
    public static IReadOnlyList<Ingredient> AvailableIngredients { get; } = new List<Ingredient>
    {
        new("Tomato Sauce", 0.50m),
        new("Mozzarella Cheese", 1.20m),
        new("Pepperoni", 1.80m),
        new("Ham", 1.50m),
        new("Pineapple", 1.00m),
        new("Basil", 0.40m),
        new("Extra Cheese", 1.00m)
    };

    public static IReadOnlyList<BaseMenuItem> AvailableBasemenuItems { get; } = new List<BaseMenuItem>
    {
        new BaseMenuItem(
            Guid.Parse("f1a2b3c4-d5e6-4789-abcd-0123456789ab"),
            "Margherita",
            7.99m,
            new List<Ingredient>
            {
                AvailableIngredients.First(i => i.Name == "Tomato Sauce"),
                AvailableIngredients.First(i => i.Name == "Mozzarella Cheese"),
                AvailableIngredients.First(i => i.Name == "Basil")
            }
        ),
        new BaseMenuItem(
            Guid.Parse("d5e6f7a8-b9c0-4d1e-8f2a-123456789abc"),
            "Pepperoni",
            9.99m,
            new List<Ingredient>
            {
                AvailableIngredients.First(i => i.Name == "Tomato Sauce"),
                AvailableIngredients.First(i => i.Name == "Mozzarella Cheese"),
                AvailableIngredients.First(i => i.Name == "Pepperoni")
            }
        ),
        new BaseMenuItem(
            Guid.Parse("9a8b7c6d-5e4f-3a2b-1c0d-abcdef123456"),
            "Hawaiian",
            10.99m,
            new List<Ingredient>
            {
                AvailableIngredients.First(i => i.Name == "Tomato Sauce"),
                AvailableIngredients.First(i => i.Name == "Mozzarella Cheese"),
                AvailableIngredients.First(i => i.Name == "Ham"),
                AvailableIngredients.First(i => i.Name == "Pineapple")
            }
        )
    };

    public static bool TryFindMenuItem(Guid menuItemId, out BaseMenuItem? baseMenuItem)
    {
        baseMenuItem = AvailableBasemenuItems.FirstOrDefault(menuItem => menuItem.Id == menuItemId);
        return baseMenuItem != null;
    }

    public static bool TryFindIngredient(string ingredientName, out Ingredient? ingredient)
    {
        ingredient = AvailableIngredients.FirstOrDefault(ingredient =>
            string.Equals(ingredient.Name, ingredientName, StringComparison.CurrentCultureIgnoreCase));
        return ingredient != null;
    }
}