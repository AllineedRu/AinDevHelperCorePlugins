using System.Collections.Generic;

namespace AinDevHelperBuilderPattern {
    /// <summary>
    /// Конкретный строитель заказа пиццы "Маргарита"
    /// </summary>
    public class MargheritaPizzaBuilder : IPizzaBuilder {
        private readonly PizzaOrder pizza = new PizzaOrder();

        public void SetSize(string size) {
            pizza.Size = size;
        }

        public void AddTopping(string topping) {
            if (pizza.Toppings == null) {
                pizza.Toppings = new List<string>();
            }
            pizza.Toppings.Add(topping);
        }

        public PizzaOrder GetPizzaOrder() {
            return pizza;
        }
    }
}