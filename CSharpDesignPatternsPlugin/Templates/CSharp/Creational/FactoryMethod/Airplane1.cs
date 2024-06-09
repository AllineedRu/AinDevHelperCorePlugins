using System;

namespace AinDevHelperFactoryMethodPattern {
    /// <summary>
    /// Класс для представления самолета
    /// </summary>    
    public class Airplane : ITransport {
        public void Drive() {
            Console.WriteLine("Летим на самолёте!");
        }
    }
}