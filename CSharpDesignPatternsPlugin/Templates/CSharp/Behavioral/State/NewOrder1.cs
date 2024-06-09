using System;

namespace AinDevHelperStatePattern {
    /// <summary>
    /// Класс состояния "Новый"
    /// </summary>
    public class NewOrder : IOrderState {
        public void ProcessOrder(Order order) {
            Console.WriteLine("Заказ обрабатывается");
            order.State = new InProcessOrder();
        }

        public void CancelOrder(Order order) {
            Console.WriteLine("Заказ отменен");
            order.State = new CancelledOrder();
        }
    }
}