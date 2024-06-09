namespace AinDevHelperStrategyPattern {
    /// <summary>
    /// Интерфейс стратегии платежа
    /// </summary>
    public interface IPaymentStrategy {
        void ProcessPayment(double amount);
    }
}