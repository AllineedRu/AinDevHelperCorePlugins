namespace AinDevHelperFactoryMethodPattern {
    /// <summary>
    /// Ниже показан пример кода на C#, демонстрирующий применение порождающего паттерна "Фабричный метод" (Factory Method) для создания объектов, 
    /// представляющих различные типы транспортных средств (например, автомобиль, велосипед, самолет).
    /// 
    /// В этом примере классы <see cref="Car"/>, <see cref="Bicycle"/> и <see cref="Airplane"/> представляют различные типы транспортных средств, реализующие интерфейс <see cref="ITransport"/>. 
    /// Классы фабрик (<see cref="CarFactory"/>, <see cref="BicycleFactory"/>, <see cref="AirplaneFactory"/>) реализуют абстрактный метод <see cref="TransportFactory.CreateTransport"/>, 
    /// который возвращает конкретный экземпляр соответствующего транспортного средства.
    /// 
    /// При запуске программы создаются экземпляры различных типов транспортных средств с помощью соответствующих фабрик, после чего они используются для выполнения действия <see cref="ITransport.Drive"/>.
    /// </summary>
    public static class Program {
        public static void Main() {
            Console.WriteLine("===================================================================================");
            Console.WriteLine("Демонстрация применения шаблона проектирования \"Фабричный метод\" (Factory Method)");
            Console.WriteLine("===================================================================================");

            TransportFactory carFactory = new CarFactory();
            ITransport car = carFactory.CreateTransport();
            car.Drive();

            TransportFactory bicycleFactory = new BicycleFactory();
            ITransport bicycle = bicycleFactory.CreateTransport();
            bicycle.Drive();

            TransportFactory airplaneFactory = new AirplaneFactory();
            ITransport airplane = airplaneFactory.CreateTransport();
            airplane.Drive();
        }
    }
}