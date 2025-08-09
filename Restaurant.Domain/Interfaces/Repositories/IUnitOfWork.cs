namespace Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IMenuItemRepository MenuItems { get; }
    IIngredientRepository Ingredients { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}