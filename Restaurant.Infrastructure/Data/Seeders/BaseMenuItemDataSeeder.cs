using Domain.Builders;
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

        // Seed Ingredients (clone from catalog to avoid sharing tracked instances across contexts)
        var ingredients = PredefinedMenuCatalog.Ingredients
            .Select(i => new Ingredient(i.Id, i.Name, i.Price))
            .ToList();

        await context.Ingredients.AddRangeAsync(ingredients, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        // Seed Menu Items built from the same ingredient instances
        var menuItems = PredefinedMenuCatalog.BuildMenuItemsFrom(ingredients).ToList();

        await context.MenuItems.AddRangeAsync(menuItems, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public static void Seed(RestaurantContext context)
    {
        
        // Skip if data already exists
        if (context.Ingredients.Any() || context.MenuItems.Any())
            return;

        // Seed Ingredients (clone from catalog to avoid sharing tracked instances across contexts)
        var ingredients = PredefinedMenuCatalog.Ingredients
            .Select(i => new Ingredient(i.Id, i.Name, i.Price))
            .ToList();

        context.Ingredients.AddRange(ingredients);
        context.SaveChanges();

        // Seed Menu Items built from the same ingredient instances
        var menuItems = PredefinedMenuCatalog.BuildMenuItemsFrom(ingredients).ToList();

        context.MenuItems.AddRange(menuItems);
        context.SaveChanges();
    }
    
    // PredefinedIngredients removed in favor of Domain.Builders.PredefinedMenuCatalog
}