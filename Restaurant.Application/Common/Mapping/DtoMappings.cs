using Domain.Entities;
using Restaurant.Application.Common.Dtos;

namespace Restaurant.Application.Common.Mapping;

public static class DtoMappings
{
    // Ingredient mappings
    public static IngredientDto ToDto(this Ingredient entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price
        };

    public static Ingredient ToEntity(this IngredientDto dto)
        // For input DTOs, we intentionally create new Ingredient instances without reusing IDs,
        // to avoid PK conflicts when attaching to a new MenuItem in EF Core.
        => new(dto.Name, dto.Price);

    public static List<IngredientDto> ToDto(this IEnumerable<Ingredient> entities)
        => entities.Select(e => e.ToDto()).ToList();

    public static List<Ingredient> ToEntities(this IEnumerable<IngredientDto> dtos)
        => dtos.Select(d => d.ToEntity()).ToList();

    // MenuItem mappings
    public static MenuItemDto ToDto(this MenuItem entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            BasePrice = entity.BasePrice,
            DefaultIngredients = entity.DefaultIngredients.ToDto()
        };

    public static List<MenuItemDto> ToDto(this IEnumerable<MenuItem> entities)
        => entities.Select(e => e.ToDto()).ToList();
}
