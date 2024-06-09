namespace AinDevHelperPrototypePattern {
    /// <summary>
    /// Пример класса документа, поддерживающего клонирование (прототип)
    /// </summary>
    public abstract class DocumentPrototype<T> {
        public string Title { get; set; }
        public string Content { get; set; }

        public abstract T Clone();
    }
}