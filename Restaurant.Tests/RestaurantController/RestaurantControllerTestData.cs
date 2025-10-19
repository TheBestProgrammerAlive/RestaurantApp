using System.Collections;
using Domain.Entities;

namespace Tests.RestaurantController;

public class RestaurantControllerTestData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [ new object[] { GenerateMargheritaPizza() } ];
        yield return [ new object[] { GeneratePepperoniPizza() } ];
        yield return [ new object[] { GenerateHawaiianPizza() } ];
    }

    private MenuItem GenerateMargheritaPizza()
    {
        // Pizza 1: Margherita
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Tomato", 0.5m),
            new Ingredient("Mozzarella", 1.0m),
            new Ingredient("Basil", 0.3m)
        };
        return new MenuItem(
            Guid.NewGuid(),
            "Margherita",
            8.99m,
            ingredients
        );
    }

    private MenuItem GeneratePepperoniPizza()
    {
        // Pizza 2: Pepperoni
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Tomato", 0.5m),
            new Ingredient("Mozzarella", 1.0m),
            new Ingredient("Pepperoni", 1.5m)
        };

        return new MenuItem(
            Guid.NewGuid(),
            "Pepperoni",
            10.99m,
            ingredients
        );
    }

    private MenuItem GenerateHawaiianPizza()
    {
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Tomato", 0.5m),
            new Ingredient("Mozzarella", 1.0m),
            new Ingredient("Ham", 1.2m),
            new Ingredient("Pineapple", 0.8m)
        };

        return new MenuItem(
            Guid.NewGuid(),
            "Hawaiian",
            11.99m,
            ingredients
        );
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}