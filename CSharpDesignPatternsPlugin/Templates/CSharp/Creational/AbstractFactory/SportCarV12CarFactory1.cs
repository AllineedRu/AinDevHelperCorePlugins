namespace AinDevHelperAbstractFactoryPattern {
    /// <summary>
    /// Класс конкретной фабрики по производству деталей к спорткарам с двигателем V12
    /// </summary>
    public class SportCarV12CarFactory : AbstractCarFactory {
        public override AbstractCarBody CreateCarBody() {
            return new SportCarV12CarBody();
        }

        public override AbstractCarEngine CreateEngine() {
            return new SportCarV12CarEngine();
        }
    }
}