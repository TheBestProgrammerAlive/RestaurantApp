using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastructure.Data.Contexts;

namespace Restaurant.Infrastructure.Data.Seeders;

public static class BaseMenuItemDataSeeder
{
    public static async Task SeedAsync(RestaurantContext context, CancellationToken cancellationToken = default)
    {
        // Skip if data already exists
        if (await context.Ingredients.AnyAsync(cancellationToken) || await context.MenuItems.AnyAsync(cancellationToken))
            return;

        // Seed Ingredients
        var ingredients = PredefinedIngredients;

        await context.Ingredients.AddRangeAsync(ingredients, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        // Seed Menu Items with default ingredients matching TestMenuData
        Ingredient Find(string name) => ingredients.First(i => i.Name == name);
        var menuItems = new List<MenuItem>
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

        await context.MenuItems.AddRangeAsync(menuItems, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public static void Seed(RestaurantContext context)
    {
        
        // Skip if data already exists
        if (context.Ingredients.Any() || context.MenuItems.Any())
            return;

        // Seed Ingredients
        var ingredients = PredefinedIngredients;

        context.Ingredients.AddRange(ingredients);
        context.SaveChanges();

        // Seed Menu Items with default ingredients matching TestMenuData
        Ingredient Find(string name) => ingredients.First(i => i.Name == name);
        var menuItems = new List<MenuItem>
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

        context.MenuItems.AddRange(menuItems);
        context.SaveChanges();
    }
    
    private static List<Ingredient> PredefinedIngredients
    {
        get
        {
            var ingredients = new List<Ingredient>
            {
                new(Guid.Parse("9F2B5574-DD8B-4C95-A25F-783940D015A9"), "Tomato Sauce", 0.50m),
                new(Guid.Parse("40A6FEA4-EEDA-4658-84CA-EB44C11919CE"), "Mozzarella Cheese", 1.20m),
                new(Guid.Parse("DC5CCD10-FAB0-4CD5-9922-97AD5D1C5713"), "Pepperoni", 1.80m),
                new(Guid.Parse("E6EDC4C0-6C88-417F-A5B7-C54EEF58E27A"), "Ham", 1.50m),
                new(Guid.Parse("5ACC482A-9AE2-4DF0-9D69-F31AE5F4791E"), "Pineapple", 1.00m),
                new(Guid.Parse("21CA2C70-B802-4AD2-91EF-D8B522936E8D"), "Basil", 0.40m),
                new(Guid.Parse("051641BC-93FE-428F-9075-BB585E27F95F"), "Extra Cheese", 1.00m)
            };
            return ingredients;
        }
    }
}