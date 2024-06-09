using System;

namespace AinDevHelperCommandPattern {
    /// <summary>
    /// Класс робота
    /// </summary>
    public class Robot {
        public void MoveForward() {
            Console.WriteLine("Робот движется вперед.");
        }

        public void MoveBackward() {
            Console.WriteLine("Робот движется назад.");
        }
    }
}