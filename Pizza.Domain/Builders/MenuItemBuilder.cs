using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Builders;

public interface IMenuItemBuilder
{
    IMenuItemBuilder WithName(string name);
    IMenuItemBuilder WithPrice(decimal price);
    IMenuItemBuilder WithIngredients(List<Ingredient> ingredients);
    BaseMenuItem Build();
}

public class MenuItemBuilder : IMenuItemBuilder
{
    private Guid _id;
    private string _name = null!;
    private decimal _price;
    private List<Ingredient> _ingredients = null!;

    public MenuItemBuilder()
    {
        Reset();
    }

    private void Reset()
    {
        _id = Guid.Empty;
        _name = string.Empty;
        _price = decimal.Zero;
        _ingredients = new List<Ingredient>();
    }

    public IMenuItemBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMenuItemBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public IMenuItemBuilder WithIngredients(List<Ingredient> ingredients)
    {
        _ingredients = ingredients;
        return this;
    }

    public BaseMenuItem Build()
    {
        var result = (_id, _name, _price, _ingredients);
        Reset();
        return new BaseMenuItem(result._id, result._name, result._price, result._ingredients);
    }
}