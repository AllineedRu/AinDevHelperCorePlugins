using System;

namespace AinDevHelperObjectPoolPattern {
    /// <summary>
    /// Пример класса, представляющего соединение к базе данных
    /// </summary>
    public class DatabaseConnection {
        public string ConnectionString { get; set; }

        public void Connect() {
            Console.WriteLine("Установлено соединение с базой данных");
        }

        public void Disconnect() {
            Console.WriteLine("Соединение с базой данных разорвано");
        }
    }
}