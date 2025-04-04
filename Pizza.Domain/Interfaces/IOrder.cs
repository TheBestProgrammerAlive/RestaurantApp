using Domain.Interfaces;

namespace Domain.Entities;

public interface IOrder
{
    void AddMenuItem(IFoodItem foodItem);
    IReadOnlyList<IModifiedFoodItem> Items { get; }
}