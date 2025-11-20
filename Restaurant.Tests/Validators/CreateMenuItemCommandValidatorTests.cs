using Domain.Entities;
using FluentValidation.TestHelper;
using Restaurant.Application.Features.MenuManagement.Commands.CreateMenuItem;

namespace Tests.Validators;

public class CreateMenuItemCommandValidatorTests
{
    CreateMenuItemCommandValidator _validator = new();

    [Theory]
    [InlineData("")]
    public void Name_ReturnsError_WhenEmpty(string name)
    {
        // arrange
        var command = CreateMenuItemCommandFactory(name);
        
        // act
        var result = _validator.TestValidate(command);
        
        // assert
        result.ShouldHaveValidationErrorFor(x => x.Name);

    }

    [Theory]
    [InlineData("someNameOverHundredCharactersLongloooooooooooooooooiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiil")]
    public void Name_ReturnsError_WhenTooLong(string name)
    {
        // arrange
        var command = CreateMenuItemCommandFactory(name);
        
        // act
        var result = _validator.TestValidate(command);
        
        // assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
        
    }

    [Theory]
    [InlineData(-1)]
    public void RequestBasePrice_ReturnsError_WhenNegative(decimal requestBasePrice)
    {
        // arrange
        var command = CreateMenuItemCommandFactory(requestBasePrice: requestBasePrice);
        // act
        var result = _validator.TestValidate(command);
        // assert
        result.ShouldHaveValidationErrorFor(x => x.RequestBasePrice);
    }

    [Fact]
    public void DefaultIngredients_ReturnsError_WhenNull()
    {
        // arrange
        var command = new CreateMenuItemCommand("CorrectName", 10, null);
        // act
        var result = _validator.TestValidate(command);
        // assert
        result.ShouldHaveValidationErrorFor(x => x.DefaultIngredients);
    }

    [Fact]
    public void CreateMenuItemCommand_ReturnsSuccess_WhenValid()
    {
        // arrange
        var name = "CorrectName";
        var requestBasePrice = 10;
        var ingredients = new List<Ingredient> { new Ingredient(Guid.NewGuid(), "Ingredient1", 10) };
        var command = CreateMenuItemCommandFactory(name, requestBasePrice, ingredients);
        
        // act
        var result = _validator.TestValidate(command);
        
        // assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    

    private CreateMenuItemCommand CreateMenuItemCommandFactory(string name = "TestName", decimal requestBasePrice = 10,
        List<Ingredient>? ingredients = null) => new CreateMenuItemCommand(name, requestBasePrice, ingredients ?? new List<Ingredient>());
}