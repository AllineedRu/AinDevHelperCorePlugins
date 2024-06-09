using System;

namespace AinDevHelperNullObjectPattern {

    /// <summary>
    /// Реализация логгера для записи в файл
    /// </summary>
    public class FileLogger : ILogger {
        public void Log(string message) {
            Console.WriteLine($"Лог в файле: {message}");
            // Здесь будет код для записи лога в файл
        }
    }
}