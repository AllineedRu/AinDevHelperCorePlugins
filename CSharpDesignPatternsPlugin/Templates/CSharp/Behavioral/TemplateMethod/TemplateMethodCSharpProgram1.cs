using System;

namespace AinDevHelperTemplateMethodPattern {
    /// <summary>
    /// Представим ситуацию, где у нас есть базовый класс DataProcessor, который определяет шаблон для обработки данных. 
    /// У нас также есть два подкласса CsvDataProcessor и ExcelDataProcessor, которые реализуют специфические шаги для обработки данных из файлов CSV и Excel соответственно.
    ///
    /// В этом примере абстрактный класс DataProcessor определяет шаблонный метод ProcessData, который вызывает последовательность операций 
    /// для обработки данных: чтение, парсинг и анализ. Подклассы CsvDataProcessor и ExcelDataProcessor реализуют конкретные шаги этих операций 
    /// в соответствии с форматом файла (CSV или Excel).
    ///
    /// В методе Main создаются экземпляры классов CsvDataProcessor и ExcelDataProcessor, после чего вызывается метод ProcessData, 
    /// который последовательно выполняет все шаги обработки данных в соответствии с шаблоном, определенным в базовом классе.
    /// </summary>
    public static class Program {

        public static void Main() {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Демонстрация применения шаблона проектирования \"Шаблонный метод\" (Template Method)");
            Console.WriteLine("=======================================================================");

            DataProcessor csvProcessor = new CsvDataProcessor();
            csvProcessor.ProcessData();

            Console.WriteLine();

            DataProcessor excelProcessor = new ExcelDataProcessor();
            excelProcessor.ProcessData();
        }
    }    
}