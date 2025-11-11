using Domain.Entities;
using Domain.Services;

namespace Tests.OrderApi;

public class OrderTests
{
    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void AddMenuItem_ShouldAddMenuItemToOrder_WhenAdded(MenuItem[] menuItems)
    {
        Order order = new Order();
        var menuItemToCheck = menuItems[0];
        foreach (var menuItem in menuItems)
        {
            order.AddItem(menuItem);
        }

        Assert.Single(order.Items, item => item.BaseMenuItem == menuItemToCheck);
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void RemoveMenuItem_ShouldRemoveMenuItemFromOrder_WhenMenuItemIsInOrder(MenuItem[] menuItems)
    {
        Order order = new Order();
        foreach (var menuItem in menuItems)
        {
            order.AddItem(menuItem);
        }

        var orderItemToRemove = order.Items.First();
        Assert.Contains(orderItemToRemove, order.Items);
        order.RemoveItem(orderItemToRemove);
        Assert.DoesNotContain(orderItemToRemove, order.Items);
    }

    [Fact]
    public void RemoveMenuItem_ShouldThrowError_WhenNoMenuItemInOrder()
    {
        Order order = new Order();
        var menuItem = new MenuItem(Guid.NewGuid(), "Test", 10m, new List<Ingredient>());
        var orderItemToRemove = new OrderItem(menuItem);
        Assert.Throws<InvalidOperationException>(() => order.RemoveItem(orderItemToRemove));
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void AddMenuItemIngredients_ShouldAddIngredients_WhenMenuItemPresentInOrder(MenuItem[] menuItems)
    {
        // arrange
        Order order = new Order();
        foreach (var menuItem in menuItems)
        {
            order.AddItem(menuItem);
        }

        var orderItemToModify = order.Items.First();
        var ingredientToAdd = TestMenuData.AvailableIngredients.First();
        // act
        order.AddIngredientToItem(orderItemToModify.Id, ingredientToAdd);
        // assert
        var addedIngredients = orderItemToModify.AddedIngredients;
        Assert.Contains(ingredientToAdd, addedIngredients);
        Assert.Single(addedIngredients);
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void RemoveMenuItemIngredients_ShouldRemoveIngredients_WhenMenuItemContainsIngredient(
        MenuItem[] menuItems)
    {
        // arrange
        Order order = new Order();
        foreach (var menuItem in menuItems)
        {
            order.AddItem(menuItem);
        }

        var orderItemToModify = order.Items.First();
        var ingredientToRemove = orderItemToModify.BaseMenuItem.DefaultIngredients.First();
        // act
        order.RemoveIngredientFromItem(orderItemToModify.Id, ingredientToRemove);
        // assert
        var removedIngredients = orderItemToModify.RemovedIngredients;
        Assert.Contains(ingredientToRemove, removedIngredients);
        Assert.Single(removedIngredients);
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void RemoveMenuItemIngredients_ShouldThrowError_WhenMenuItemDoesNotContainIngredient(
        MenuItem[] menuItems)
    {
        // arrange
        Order order = new Order();
        foreach (var menuItem in menuItems)
        {
            order.AddItem(menuItem);
        }

        var orderItemToModify = order.Items.First();
        var ingredientNotInBase = new Ingredient("NonExistent", 1.0m);
        // act & assert
        Assert.Throws<InvalidOperationException>(() =>
            order.RemoveIngredientFromItem(orderItemToModify.Id, ingredientNotInBase));
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void CalculateOrder_ShouldReturnOrderPrice_WhenOrderCorrect(MenuItem[] menuItems)
    {
        // arrange
        Order order = new Order();
        foreach (var menuItem in menuItems)
        {
            order.AddItem(menuItem);
        }

        var orderEvaluator = new OrderEvaluatorService();
        // act
        var expectedPrice = menuItems.Select(item => item.BasePrice).Sum();
        var evaluatedPrice = orderEvaluator.CalculateOrder(order);
        // assert
        Assert.Equal(expectedPrice, evaluatedPrice);
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void CalculateOrder_ShouldCalculateCorrectly_WhenIngredientsModified(MenuItem[] menuItems)
    {
        // arrange
        Order order = new Order();
        foreach (var menuItem in menuItems)
        {
            order.AddItem(menuItem);
        }

        var orderEvaluator = new OrderEvaluatorService();
        var ingredientToAdd = Tests.TestMenuData.AvailableIngredients.First();
        var orderItemIdToModify = order.Items.First().Id;
        // act
        order.AddIngredientToItem(orderItemIdToModify, ingredientToAdd);
        var expectedPrice = menuItems.Select(item => item.BasePrice).Sum() + ingredientToAdd.Price;
        var evaluatedPrice = orderEvaluator.CalculateOrder(order);
        // assert
        Assert.Equal(expectedPrice, evaluatedPrice);
    }
}