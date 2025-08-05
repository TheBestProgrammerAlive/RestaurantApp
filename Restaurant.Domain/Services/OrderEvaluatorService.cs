using Domain.Interfaces.Entities;

namespace Domain.Services;

public interface IOrderEvaluatorService
{
    decimal CalculateOrder(IOrder order);
}

public class OrderEvaluatorService : IOrderEvaluatorService
{
    public decimal CalculateOrder(IOrder order) => order.Items.Sum(item => item.Price);
}