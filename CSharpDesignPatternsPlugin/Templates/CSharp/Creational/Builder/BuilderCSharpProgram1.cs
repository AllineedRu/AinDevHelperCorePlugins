namespace AinDevHelperBuilderPattern {
    /// <summary>
    /// Пример использования порождающего паттерна "Строитель" (Builder)
    /// В этом примере класс <see cref="PizzaOrder" /> представляет заказ пиццы, а интерфейс <see cref="IPizzaBuilder" /> определяет 
    /// методы для установки размера пиццы и добавления топпингов к заказу пиццы. 
    /// Класс <see cref="MargheritaPizzaBuilder" /> реализует интерфейс <see cref="IPizzaBuilder" /> для создания заказа пиццы "Маргарита". 
    /// Директор <see cref="PizzaDirector" /> управляет процессом сборки заказа пиццы.
    ///
    /// При запуске программы создается заказ пиццы "Маргарита" с указанными размером и топпингами, после чего он отображается на консоли.
    /// </summary>
    public static class Program {
        public static void Main() {
            Console.WriteLine("======================================================================");
            Console.WriteLine("Демонстрация применения шаблона проектирования \"Строитель\" (Builder)");
            Console.WriteLine("======================================================================");

            IPizzaBuilder margheritaPizzaBuilder = new MargheritaPizzaBuilder();
            PizzaDirector director = new PizzaDirector(margheritaPizzaBuilder);

            director.ConstructPizza();
            PizzaOrder pizzaOrder = margheritaPizzaBuilder.GetPizzaOrder();

            pizzaOrder.DisplayOrder();
        }
    }
}