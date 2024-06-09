namespace AinDevHelperStrategyPattern {
    /// <summary>
    /// Класс, который использует стратегию платежа
    /// </summary>
    public class PaymentProcessor {
        private IPaymentStrategy _paymentStrategy;

        public PaymentProcessor(IPaymentStrategy paymentStrategy) {
            _paymentStrategy = paymentStrategy;
        }

        public void ProcessOrder(double amount) {
            _paymentStrategy.ProcessPayment(amount);
        }
    }
}