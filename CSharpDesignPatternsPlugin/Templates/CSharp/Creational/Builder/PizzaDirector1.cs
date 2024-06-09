namespace AinDevHelperBuilderPattern {
    /// <summary>
    /// Директор, который управляет процессом сборки заказа пиццы
    /// </summary>
    public class PizzaDirector {
        private readonly IPizzaBuilder pizzaBuilder;

        public PizzaDirector(IPizzaBuilder builder) {
            pizzaBuilder = builder;
        }

        public void ConstructPizza() {
            pizzaBuilder.SetSize("Большая");
            pizzaBuilder.AddTopping("Сыр");
            pizzaBuilder.AddTopping("Томаты");
            pizzaBuilder.AddTopping("Базилик");
        }
    }
}