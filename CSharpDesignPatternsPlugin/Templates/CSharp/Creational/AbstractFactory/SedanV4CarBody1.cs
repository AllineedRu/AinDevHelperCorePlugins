using System;

namespace AinDevHelperAbstractFactoryPattern {
    /// <summary>
    /// Класс для корпусов автомобилей-седанов с двигателем V4
    /// </summary>
    public class SedanV4CarBody : AbstractCarBody {
        public override void PrintCarBodyDetails() {
            Console.WriteLine("Сейчас мы в экземпляре SedanV4CarBody. Это класс для корпуса автомобиля седан с V4 двигателем.");
        }
    }
}