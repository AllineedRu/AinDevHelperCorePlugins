﻿using System;

namespace AinDevHelperNullObjectPattern {
    /// <summary>
    /// Паттерн "Нулевой объект" (Null Object) используется для предоставления объекта-заглушки, который реализует интерфейс, но не выполняет никаких действий. 
    /// Этот паттерн полезен, когда необходимо избежать проверок на null и обеспечить более безопасное поведение программы.
    /// 
    /// Рассмотрим пример применения паттерна "Нулевой объект" на примере логгирования в приложении. У нас есть интерфейс ILogger, 
    /// который определяет метод для записи логов. Мы создадим два класса: FileLogger, который сохраняет логи в файл, и NullLogger, 
    /// который представляет нулевой объект и не выполняет никаких действий.
    ///
    /// В данном примере, если мы используем FileLogger, то логи будут записываться в файл. Однако, если мы заменим FileLogger на NullLogger, 
    /// то операции записи логов будут проходить без ошибок, но никакой реальной записи не будет произведено. 
    /// Это позволяет избежать проверок на null и обеспечить более гладкое выполнение программы.
    /// </summary>
    public static class Program {

        public static void Main() {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Демонстрация применения шаблона проектирования \"Нулевой объект\" (Null Object)");
            Console.WriteLine("=======================================================================");

            // Пример использования паттерна "Нулевой объект"
            ILogger logger = new FileLogger(); // Или NullLogger() для использования нулевого объекта

            logger.Log("Запись лога 1");
            logger.Log("Запись лога 2");
        }
    }    
}