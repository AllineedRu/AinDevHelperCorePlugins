namespace AinDevHelperVisitorPattern {
    /// <summary>
    /// Класс "Треугольник", реализующий интерфейс <see cref="IShape" />
    /// </summary>
    public class Triangle : IShape {
        /// <summary>
        /// Величина основания треугольника
        /// </summary>
        public double Base { get; set; }

        /// <summary>
        /// Величина высоты треугольника, проведённой к основанию
        /// </summary>
        public double Height { get; set; }

        public void Accept(IVisitor visitor) {
            visitor.VisitTriangle(this);
        }
    }
}
