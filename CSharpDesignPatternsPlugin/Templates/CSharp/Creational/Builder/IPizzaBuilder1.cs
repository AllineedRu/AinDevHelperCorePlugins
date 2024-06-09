namespace AinDevHelperBuilderPattern {
    /// <summary>
    /// Интерфейс строителя заказа пиццы
    /// </summary>
    public interface IPizzaBuilder {
        void SetSize(string size);
        void AddTopping(string topping);
        PizzaOrder GetPizzaOrder();
    }
}