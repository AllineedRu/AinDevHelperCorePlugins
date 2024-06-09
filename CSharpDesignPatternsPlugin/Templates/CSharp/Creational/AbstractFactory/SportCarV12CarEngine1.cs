using System;

namespace AinDevHelperAbstractFactoryPattern {
    /// <summary>
    /// Класс для двигателей к спорткарам с двигателем V12
    /// </summary>
    public class SportCarV12CarEngine : AbstractCarEngine {
        public override void PrintCarEngineDetails() {
            Console.WriteLine("Сейчас мы в экземпляре SportCarV12CarEngine. Это класс для V12 двигателя спорткара.");
        }
    }
}