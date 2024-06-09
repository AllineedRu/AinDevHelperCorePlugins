﻿namespace AinDevHelperStatePattern {
    /// <summary>
    /// Класс заказа
    /// </summary>
    public class Order {
        public IOrderState State { get; set; }

        public Order() {
            State = new NewOrder(); // Начальное состояние - "Новый"
        }

        public void ProcessOrder() {
            State.ProcessOrder(this);
        }

        public void CancelOrder() {
            State.CancelOrder(this);
        }
    }
}