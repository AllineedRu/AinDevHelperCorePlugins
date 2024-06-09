using System;

namespace AinDevHelperFactoryMethodPattern {
    /// <summary>
    /// Класс для представления велосипеда
    /// </summary>
    public class Bicycle : ITransport {
        public void Drive() {
            Console.WriteLine("Едем на велосипеде!");
        }
    }
}