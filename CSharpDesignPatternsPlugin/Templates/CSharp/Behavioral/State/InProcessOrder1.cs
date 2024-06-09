using System;

namespace AinDevHelperStatePattern {
    /// <summary>
    /// Класс состояния "Обрабатывается"
    /// </summary>
    public class InProcessOrder : IOrderState {
        public void ProcessOrder(Order order) {
            Console.WriteLine("Заказ уже обрабатывается");
        }

        public void CancelOrder(Order order) {
            Console.WriteLine("Заказ отменен");
            order.State = new CancelledOrder();
        }
    }
}