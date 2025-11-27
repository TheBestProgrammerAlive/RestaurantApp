namespace Restaurant.Application.Common.Dtos;

public class MenuItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public List<IngredientDto> DefaultIngredients { get; set; } = new();
}