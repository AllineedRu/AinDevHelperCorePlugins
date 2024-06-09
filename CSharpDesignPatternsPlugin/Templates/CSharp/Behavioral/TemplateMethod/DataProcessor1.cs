namespace AinDevHelperTemplateMethodPattern {
    /// <summary>
    /// Абстрактный класс, определяющий шаблонный метод <see cref="ProcessData" /> для обработки данных
    /// </summary>
    public abstract class DataProcessor {
        /// <summary>
        /// Шаблонный метод
        /// </summary>
        public void ProcessData() {
            ReadData();
            ParseData();
            AnalyzeData();
            // Дополнительные шаги могут быть добавлены здесь ...
        }

        // Абстрактные методы, которые должны быть реализованы в подклассах
        protected abstract void ReadData();
        protected abstract void ParseData();
        protected abstract void AnalyzeData();
    }   
}