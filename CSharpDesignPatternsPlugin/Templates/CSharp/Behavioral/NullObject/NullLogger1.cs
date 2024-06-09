namespace AinDevHelperNullObjectPattern {

    /// <summary>
    /// Нулевой объект логгера
    /// </summary>
    public class NullLogger : ILogger {
        public void Log(string message) {
            // Ничего не делаем, так как это нулевой объект
        }
    }
}