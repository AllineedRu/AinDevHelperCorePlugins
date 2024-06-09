using System;

namespace AinDevHelperStrategyPattern {
    /// <summary>
    /// Реализация стратегии оплаты кредитной картой
    /// </summary>
    public class CreditCardPaymentStrategy : IPaymentStrategy {
        public void ProcessPayment(double amount) {
            Console.WriteLine($"Оплата кредитной картой на сумму: {amount}");
            // Здесь будет код для обработки платежа кредитной картой
        }
    }
}