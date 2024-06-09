using System;

namespace AinDevHelperPrototypePattern {
    /// <summary>
    /// Конкретный класс документа
    /// </summary>
    public class Document : DocumentPrototype<Document> {
        public override Document Clone() {
            return new Document { Title = this.Title, Content = this.Content };
        }

        public void DisplayInfo() {
            Console.WriteLine($"Документ: {Title}");
            Console.WriteLine($"Содержание: {Content}");
        }
    }
}