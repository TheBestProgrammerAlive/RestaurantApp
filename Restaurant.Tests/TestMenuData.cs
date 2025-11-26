using Domain.Builders;
using Domain.Entities;

namespace Tests;

/// <summary>
/// Centralized test-only data source that mirrors the old in-memory Menu data.
/// </summary>
public static class TestMenuData
{
    // Use the shared catalog to ensure alignment with seeding
    public static IReadOnlyList<Ingredient> AvailableIngredients { get; } = PredefinedMenuCatalog.Ingredients;

    public static IReadOnlyList<MenuItem> AvailableBaseMenuItems { get; } =
        PredefinedMenuCatalog.BuildMenuItemsFrom(AvailableIngredients);
}