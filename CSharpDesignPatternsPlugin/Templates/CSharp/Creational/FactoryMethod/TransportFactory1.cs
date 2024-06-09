namespace AinDevHelperFactoryMethodPattern {
    /// <summary>
    /// Фабричный метод для создания различных типов транспортных средств
    /// </summary>
    public abstract class TransportFactory {
        public abstract ITransport CreateTransport();
    }
}