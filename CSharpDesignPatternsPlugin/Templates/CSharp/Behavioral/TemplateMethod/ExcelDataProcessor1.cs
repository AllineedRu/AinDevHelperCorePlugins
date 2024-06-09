using System;

namespace AinDevHelperTemplateMethodPattern {
    /// <summary>
    /// Конкретный класс для обработки данных из Excel-файла
    /// </summary>
    public class ExcelDataProcessor : DataProcessor {
        protected override void ReadData() {
            Console.WriteLine("Чтение данных из Excel-файла");
        }

        protected override void ParseData() {
            Console.WriteLine("Парсинг данных из Excel-файла");
        }

        protected override void AnalyzeData() {
            Console.WriteLine("Анализ данных из Excel-файла");
        }
    }
}