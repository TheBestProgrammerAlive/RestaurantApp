using FluentValidation;

namespace Restaurant.Application.Features.MenuManagement.Commands.CreateMenuItem;

public sealed class CreateMenuItemCommandValidator : AbstractValidator<CreateMenuItemCommand>
{
    public CreateMenuItemCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.RequestBasePrice)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.DefaultIngredients)
            .NotNull();
    }
}