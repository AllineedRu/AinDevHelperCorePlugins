namespace AinDevHelperFactoryMethodPattern {
    /// <summary>
    /// Фабрика для создания автомобилей
    /// </summary>    
    public class CarFactory : TransportFactory {
        public override ITransport CreateTransport() {
            return new Car();
        }
    }
}