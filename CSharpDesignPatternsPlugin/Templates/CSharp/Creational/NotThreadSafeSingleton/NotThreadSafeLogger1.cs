using System;

namespace AinDevHelperNotThreadSafeSingletonPattern {
    public sealed class Logger {
        /// <summary>
        /// Закрытое статическое поле класса, которое хранит ссылку на экземпляр класса-синглтона Logger
        /// </summary>
        private static Logger? instance;

        /// <summary>
        /// Строка, содержащая полный лог с сообщениями
        /// </summary>
        private string log;

        /// <summary>
        /// Конструктор класса-синглтона - закрытый (private) для запрета прямого создания экземпляров
        /// класса в вызывающем коде: единственный способ получить экземпляр класса - это обратиться
        /// к статическому свойству <see cref="Instance" />
        /// </summary>
        private Logger() {
            log = "Начальная запись в логе";
        }

        /// <summary>
        /// Метод GetInstance получает экземпляр класса Logger, если он уже был создан или создаёт его, если он в момент
        /// запроса равен null. К сожалению, данная реализация не является потокобезопасной, поскольку существует вероятность,
        /// что в многопоточном приложении два или более потоков одновременно попытаются выполнить проверку в операторе if
        /// и создать экземпляр класса Logger. Поэтому данный вариант может применяться в случаях, когда разные потоки не будут
        /// одновременно получать доступ к экземпляру класса-синглтона.
        /// </summary>
        public static Logger GetInstance() {
            if (instance == null) {
                instance = new Logger();
            }
            return instance;
        }

        /// <summary>
        /// Метод для добавления нового сообщения в лог
        /// </summary>
        public void Log(string message) {
            log += "\n" + message;
        }

        /// <summary>
        /// Метод для распечатки полного лога на экране консоли
        /// </summary>
        public void PrintLog() {
            Console.WriteLine(log);
        }
    }
}