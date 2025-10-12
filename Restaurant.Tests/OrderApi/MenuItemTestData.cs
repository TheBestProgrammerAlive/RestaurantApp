using System.Collections;
using Domain.Entities;

namespace Tests.OrderApi;

public class MenuItemTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return
        [
            new[]
            {
                GenerateMargheritaPizza(),
                GeneratePepperoniPizza(),
                GenerateHawaiianPizza()
            }
        ];
    }

    private BaseMenuItem GenerateMargheritaPizza()
    {
        // Pizza 1: Margherita
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Tomato", 0.5m),
            new Ingredient("Mozzarella", 1.0m)
        };
        var additionalIngredients1 = new List<Ingredient>
        {
            new Ingredient("Basil", 0.3m)
        };
        return new ModifiedMenuItem(
            Guid.NewGuid(),
            "Margherita",
            8.99m,
            ingredients,
            new List<Ingredient>()
        );
    }

    private BaseMenuItem GeneratePepperoniPizza()
    {
        // Pizza 2: Pepperoni
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Tomato", 0.5m),
            new Ingredient("Mozzarella", 1.0m),
            new Ingredient("Pepperoni", 1.5m)
        };

        return new ModifiedMenuItem(
            Guid.NewGuid(),
            "Pepperoni",
            10.99m,
            ingredients,
            new List<Ingredient>()
        );
    }

    private BaseMenuItem GenerateHawaiianPizza()
    {
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Tomato", 0.5m),
            new Ingredient("Mozzarella", 1.0m),
            new Ingredient("Ham", 1.2m),
            new Ingredient("Pineapple", 0.8m)
        };

        return new ModifiedMenuItem(
            Guid.NewGuid(),
            "Hawaiian",
            11.99m,
            ingredients,
            new List<Ingredient>()
        );
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}