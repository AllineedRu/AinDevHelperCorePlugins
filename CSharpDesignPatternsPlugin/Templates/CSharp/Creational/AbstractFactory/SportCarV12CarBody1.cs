﻿using System;

namespace AinDevHelperAbstractFactoryPattern {
    /// <summary>
    /// Класс для корпусов автомобилей-спорткаров с двигателем V12
    /// </summary>
    public class SportCarV12CarBody : AbstractCarBody {
        public override void PrintCarBodyDetails() {
            Console.WriteLine("Сейчас мы в экземпляре SportCarV12CarBody. Это класс для корпуса спорткара с V12 двигателем.");
        }
    }
}