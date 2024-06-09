namespace AinDevHelperVisitorPattern {
    /// <summary>
    /// Интерфейс представляет собой абстрактную фигуру и в методе <see cref="Accept" /> умеет принимать
    /// на вход экземпляр посетителя, представленный интерфейсом <see cref="IVisitor" />
    /// </summary>
    public interface IShape {
        void Accept(IVisitor visitor);
    }
}