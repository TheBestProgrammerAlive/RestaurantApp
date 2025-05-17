using Domain.Entities;
using Domain.Services;

namespace Tests.OrderApi;

public class OrderTests
{
    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void AddMenuItem_ShouldAddMenuItemToOrder_WhenAdded(ModifiedMenuItem[] menuItems)
    {
        Order order = new Order();
        var menuItemToCheck = menuItems[0];
        foreach (var menuItem in menuItems)
        {
            order.AddMenuItem(menuItem);
        }

        Assert.Contains(menuItemToCheck, order.Items);
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void RemoveMenuItem_ShouldRemoveMenuItemFromOrder_WhenMenuItemIsInOrder(ModifiedMenuItem[] menuItems)
    {
        Order order = new Order();
        var menuItemToRemove = menuItems[0];
        foreach (var menuItem in menuItems)
        {
            order.AddMenuItem(menuItem);
        }

        Assert.Contains(menuItemToRemove, order.Items);
        order.RemoveMenuItem(menuItemToRemove);
        Assert.DoesNotContain(menuItemToRemove, order.Items);
    }

    [Fact]
    public void RemoveMenuItem_ShouldThrowError_WhenNoMenuItemInOrder()
    {
        Order order = new Order();
        var menuItemToRemove = new ModifiedMenuItem();
        Assert.Throws<InvalidOperationException>(() => order.RemoveMenuItem(menuItemToRemove));
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void AddMenuItemIngredients_ShouldAddIngredients_WhenMenuItemPresentInOrder(ModifiedMenuItem[] menuItems)
    {
        // arrange
        Order order = new Order();
        var menuItemToModify = menuItems[0];
        foreach (var menuItem in menuItems)
        {
            order.AddMenuItem(menuItem);
        }

        var ingredientToAdd = Menu.AvailableIngredients.First();
        // act
        order.AddAdditionalIngredients(menuItemToModify.Id, ingredientToAdd);
        // assert
        var additionalIngredients = menuItemToModify.AdditionalIngredients;
        Assert.Contains(ingredientToAdd, additionalIngredients);
        Assert.Single(additionalIngredients);
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void RemoveMenuItemIngredients_ShouldRemoveIngredients_WhenMenuItemContainsIngredient(
        ModifiedMenuItem[] menuItems)
    {
        // arrange
        Order order = new Order();
        var menuItemToModify = menuItems[0];
        foreach (var menuItem in menuItems)
        {
            order.AddMenuItem(menuItem);
        }

        var ingredientToRemove = Menu.AvailableIngredients.First();
        // act
        var additionalIngredients = menuItemToModify.AdditionalIngredients;
        order.AddAdditionalIngredients(menuItemToModify.Id, ingredientToRemove);
        Assert.Contains(ingredientToRemove, additionalIngredients);
        Assert.Single(additionalIngredients);
        order.RemoveAdditionalIngredient(menuItemToModify.Id, ingredientToRemove);
        // assert
        Assert.DoesNotContain(ingredientToRemove, additionalIngredients);
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void RemoveMenuItemIngredients_ShouldThrowError_WhenMenuItemDoesNotContainIngredient(
        ModifiedMenuItem[] menuItems)
    {
        // arrange
        Order order = new Order();
        var menuItemToModify = menuItems[0];
        foreach (var menuItem in menuItems)
        {
            order.AddMenuItem(menuItem);
        }

        var ingredientToRemove = Menu.AvailableIngredients.First();
        // act
        // assert
        Assert.Throws<InvalidOperationException>(() =>
            order.RemoveAdditionalIngredient(menuItemToModify.Id, ingredientToRemove));
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void CalculateOrder_ShouldReturnOrderPrice_WhenOrderCorrect(ModifiedMenuItem[] menuItems)
    {
        // arrange
        Order order = new Order();
        foreach (var menuItem in menuItems)
        {
            order.AddMenuItem(menuItem);
        }

        var orderEvaluator = new OrderEvaluatorService();
        // act
        var expectedPrice = menuItems.Select(item => item.Price).Sum();
        var evaluatedPrice = orderEvaluator.CalculateOrder(order);
        // assert
        Assert.Equal(expectedPrice, evaluatedPrice);
    }

    [Theory]
    [ClassData(typeof(MenuItemTestData))]
    public void CalculateOrder_ShouldCalculateCorrectly_WhenIngredientsModified(ModifiedMenuItem[] menuItems)
    {
        // arrange
        Order order = new Order();
        foreach (var menuItem in menuItems)
        {
            order.AddMenuItem(menuItem);
        }

        var orderEvaluator = new OrderEvaluatorService();
        var ingredientToAdd = Menu.AvailableIngredients.First();
        var menuIdToModify = menuItems.First().Id;
        // act
        order.AddAdditionalIngredients(menuIdToModify, ingredientToAdd);
        var expectedPrice = menuItems.Select(item => item.Price).Sum();
        var evaluatedPrice = orderEvaluator.CalculateOrder(order);
        // assert
        Assert.Equal(expectedPrice, evaluatedPrice);
    }
}