namespace AinDevHelperVisitorPattern {
    /// <summary>
    /// Класс "Круг", реализующий интерфейс <see cref="IShape" />
    /// </summary>
    public class Circle : IShape {
        /// <summary>
        /// Радиус круга
        /// </summary>
        public double Radius { get; set; }

        public void Accept(IVisitor visitor) {
            visitor.VisitCircle(this);
        }
    }
}
