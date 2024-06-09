namespace AinDevHelperVisitorPattern {
    /// <summary>
    /// Класс "Прямоугольник", реализующий интерфейс <see cref="IShape" />
    /// </summary>
    public class Rectangle : IShape {
        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Высота прямоугольника
        /// </summary>
        public double Height { get; set; }

        public void Accept(IVisitor visitor) {
            visitor.VisitRectangle(this);
        }
    }
}
