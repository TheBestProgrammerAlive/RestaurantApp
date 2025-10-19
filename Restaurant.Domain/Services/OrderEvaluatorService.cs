namespace Domain.Services;

public interface IOrderEvaluatorService
{
    decimal CalculateOrder(Domain.Entities.Order order);
}

public class OrderEvaluatorService : IOrderEvaluatorService
{
    /// <summary>
    /// Calculates the total price of an order including all customizations.
    /// Each OrderItem calculates its own price based on base price and modifications.
    /// </summary>
    public decimal CalculateOrder(Domain.Entities.Order order) => order.CalculateTotal();
}