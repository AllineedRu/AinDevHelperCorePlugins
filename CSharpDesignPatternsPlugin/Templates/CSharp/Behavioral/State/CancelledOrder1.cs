using System;

namespace AinDevHelperStatePattern {
    /// <summary>
    /// Класс состояния "Отменен"
    /// </summary>
    public class CancelledOrder : IOrderState {
        public void ProcessOrder(Order order) {
            Console.WriteLine("Нельзя обработать отмененный заказ");
        }

        public void CancelOrder(Order order) {
            Console.WriteLine("Заказ уже отменен");
        }
    }
}