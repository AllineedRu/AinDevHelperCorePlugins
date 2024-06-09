namespace AinDevHelperVisitorPattern {
    /// <summary>
    /// Класс "Квадрат", реализующий интерфейс <see cref="IShape" />
    /// </summary>
    public class Square : IShape {
        /// <summary>
        /// Величина стороны квадрата
        /// </summary>
        public double SideLength { get; set; }

        public void Accept(IVisitor visitor) {
            visitor.VisitSquare(this);
        }
    }
}
