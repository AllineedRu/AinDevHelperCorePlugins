using System;

namespace AinDevHelperAbstractFactoryPattern {
    /// <summary>
    /// Класс для двигателей к седанам с двигателем V4
    /// </summary>
    public class SedanV4CarEngine : AbstractCarEngine {
        public override void PrintCarEngineDetails() {
            Console.WriteLine("Сейчас мы в экземпляре SedanV4CarEngine. Это класс для V4 двигателя седана.");
        }
    }
}