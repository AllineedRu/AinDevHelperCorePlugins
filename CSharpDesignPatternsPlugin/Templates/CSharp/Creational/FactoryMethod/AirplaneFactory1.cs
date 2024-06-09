namespace AinDevHelperFactoryMethodPattern {
    /// <summary>
    /// Фабрика для создания самолетов
    /// </summary>
    public class AirplaneFactory : TransportFactory {
        public override ITransport CreateTransport() {
            return new Airplane();
        }
    }
}