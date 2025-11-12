using FluentValidation;

namespace Restaurant.Application.Features.MenuManagement.Queries.GetMenuItem;

public sealed class GetMenuItemQueryValidator: AbstractValidator<GetMenuItemQuery>
{
    public GetMenuItemQueryValidator()
    {
        RuleFor(x => x.MenuItemId).NotEmpty();
    }
    
}