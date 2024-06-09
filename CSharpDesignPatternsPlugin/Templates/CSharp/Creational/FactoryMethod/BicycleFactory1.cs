namespace AinDevHelperFactoryMethodPattern {
    /// <summary>
    /// Фабрика для создания велосипедов
    /// </summary>
    public class BicycleFactory : TransportFactory {
        public override ITransport CreateTransport() {
            return new Bicycle();
        }
    }
}