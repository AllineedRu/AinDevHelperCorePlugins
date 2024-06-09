using System;

namespace AinDevHelperStrategyPattern {
    /// <summary>
    /// Реализация стратегии оплаты через PayPal
    /// </summary>
    public class PayPalPaymentStrategy : IPaymentStrategy {
        public void ProcessPayment(double amount) {
            Console.WriteLine($"Оплата через PayPal на сумму: {amount}");
            // Здесь будет код для обработки платежа через PayPal
        }
    }
}