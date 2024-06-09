using System;

namespace AinDevHelperFactoryMethodPattern {
    /// <summary>
    /// Класс для представления автомобиля
    /// </summary>    
    public class Car : ITransport {
        public void Drive() {
            Console.WriteLine("Едем на машине!");
        }
    }
}