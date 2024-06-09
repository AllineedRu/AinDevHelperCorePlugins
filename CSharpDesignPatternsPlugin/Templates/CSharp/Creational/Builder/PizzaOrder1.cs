using System;
using System.Collections.Generic;

namespace AinDevHelperBuilderPattern {
    /// <summary>
    /// Пример класса, представляющего заказ пиццы
    /// </summary>
    public class PizzaOrder {
        public string Size { get; set; }
        public List<string> Toppings { get; set; }

        public void DisplayOrder() {
            Console.WriteLine("Заказ на пиццу:");
            Console.WriteLine("Размер: " + Size);
            Console.WriteLine("Топпинги:");

            foreach (var topping in Toppings) {
                Console.WriteLine("- " + topping);
            }
        }
    }
}