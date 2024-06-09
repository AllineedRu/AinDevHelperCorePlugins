namespace AinDevHelperAbstractFactoryPattern {
    /// <summary>
    /// Класс конкретной фабрики по производству деталей к седанам с двигателем V4
    /// </summary>
    public class SedanV4CarFactory : AbstractCarFactory {
        public override AbstractCarBody CreateCarBody() {
            return new SedanV4CarBody();
        }

        public override AbstractCarEngine CreateEngine() {
            return new SedanV4CarEngine();
        }
    }
}