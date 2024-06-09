using System;

namespace AinDevHelperTemplateMethodPattern {
    /// <summary>
    /// Конкретный класс для обработки данных из CSV-файла
    /// </summary>
    public class CsvDataProcessor : DataProcessor {
        protected override void ReadData() {
            Console.WriteLine("Чтение данных из CSV-файла");
        }

        protected override void ParseData() {
            Console.WriteLine("Парсинг данных из CSV-файла");
        }

        protected override void AnalyzeData() {
            Console.WriteLine("Анализ данных из CSV-файла");
        }
    }
  
}