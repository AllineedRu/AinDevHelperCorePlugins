namespace AinDevHelperMementoPattern {
    /// <summary>
    /// Класс, представляющий состояние текстового документа
    /// </summary>
    public class TextDocumentMemento
    {
        public string Text { get; }

        public TextDocumentMemento(string text)
        {
            Text = text;
        }
    }
}