using System;

namespace AinDevHelperStrategyPattern {
    /// <summary>
    /// Паттерн "Стратегия" (Strategy) используется для определения семейства алгоритмов, инкапсуляции каждого из них и обеспечения их взаимозаменяемости. 
    /// Рассмотрим пример применения паттерна "Стратегия" на примере обработки платежей в интернет-магазине.
    ///
    /// У нас есть интерфейс IPaymentStrategy, который определяет метод для проведения платежа, и две конкретные реализации этого интерфейса: 
    /// CreditCardPaymentStrategy для оплаты кредитной картой и PayPalPaymentStrategy для оплаты через PayPal.
    ///
    /// В данном примере мы создаем две стратегии для обработки платежей: оплата кредитной картой и оплата через PayPal. 
    /// Затем мы создаем экземпляры PaymentProcessor, каждому из которых передаем конкретную стратегию. 
    /// При вызове метода ProcessOrder у PaymentProcessor будет выполнен соответствующий алгоритм оплаты в зависимости от выбранной стратегии. 
    /// Это позволяет легко добавлять новые способы оплаты без изменения основного кода и обеспечивает гибкость системы.
    /// </summary>
    public static class Program {

        public static void Main() {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Демонстрация применения шаблона проектирования \"Стратегия\" (Strategy)");
            Console.WriteLine("=======================================================================");

            // Пример использования паттерна "Стратегия" для обработки платежей
            PaymentProcessor creditCardPaymentProcessor = new PaymentProcessor(new CreditCardPaymentStrategy());
            creditCardPaymentProcessor.ProcessOrder(100.50);

            PaymentProcessor paypalPaymentProcessor = new PaymentProcessor(new PayPalPaymentStrategy());
            paypalPaymentProcessor.ProcessOrder(75.25);
        }
    }    
}