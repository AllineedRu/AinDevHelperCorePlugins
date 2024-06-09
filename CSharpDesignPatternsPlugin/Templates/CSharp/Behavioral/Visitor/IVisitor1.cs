namespace AinDevHelperVisitorPattern {
    /// <summary>
    /// Интерфейс для посетителя. Содержит методы посещения конкретных экземпляров классов, реализующих интерфейс <see cref="IShape"/>
    /// </summary>
    public interface IVisitor {
        void VisitCircle(Circle circle);
        void VisitSquare(Square square);
        void VisitTriangle(Triangle triangle);
        void VisitRectangle(Rectangle rectangle);
    }
}
