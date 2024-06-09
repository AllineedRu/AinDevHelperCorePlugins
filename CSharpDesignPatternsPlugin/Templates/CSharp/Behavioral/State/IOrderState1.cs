namespace AinDevHelperStatePattern {
    /// <summary>
    /// Интерфейс для состояния заказа
    /// </summary>    
    public interface IOrderState {
        void ProcessOrder(Order order);
        void CancelOrder(Order order);
    }
}