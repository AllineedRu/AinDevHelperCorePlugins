using System;

namespace AinDevHelperMementoPattern {
    public static class MementoConsoleUtils {
        /// <summary>
        /// Вывод сообщения <paramref name="message"/> на консоль с указанным цветом <paramref name="consoleForegroundColor"/> текста
        /// </summary>
        /// <param name="message">сообщение для вывода на консоль</param>
        /// <param name="consoleForegroundColor">цвет текста</param>
        public static void WriteLineWithColor(string message, ConsoleColor consoleForegroundColor) {
            var oldForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleForegroundColor;
            Console.WriteLine(message);
            Console.ForegroundColor = oldForegroundColor;
        }
    }
}
