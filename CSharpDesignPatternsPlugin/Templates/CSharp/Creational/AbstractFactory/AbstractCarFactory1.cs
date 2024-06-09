namespace AinDevHelperAbstractFactoryPattern {
    /// <summary>
    /// Абстрактный класс фабрики по изготовлению частей для автомобилей (двигатели и корпуса).
    /// Абстрактные методы <see cref="CreateEngine" /> и <see cref="CreateCarBody" /> должны быть реализованы в конкретном классе специфичной фабрики, 
    /// наследующемся от данного класса, и возвращать экземпляры конкретных соответствующих классов-наследников, отвечающих за конкретный тип двигателя/корпуса автомобиля.
    /// Статический метод <see cref="GetFactory{T}" /> вызывается на стороне программы-клиента для получения конкретного экземпляра фабрики
    /// с целью производства деталей заданного типа.
    /// </summary>
    public abstract class AbstractCarFactory {
        /// <summary>
        /// Создать соответствующий тип двигателя для автомобиля
        /// </summary>
        /// <returns>возвращает экземпляр конкретного типа двигателя для автомобиля</returns>
        public abstract AbstractCarEngine CreateEngine();

        /// <summary>
        /// Создать соответствующий тип корпуса для автомобиля
        /// </summary>
        /// <returns>возвращает экземпляр конкретного типа корпуса для автомобиля</returns>
        public abstract AbstractCarBody CreateCarBody();

        /// <summary>
        /// Метод для получения экземпляра конкретной фабрики (класса, наследующегося от текущего класса <see cref="AbstractCarFactory"/>
        /// </summary>
        /// <typeparam name="T">класс для конкретной фабрики</typeparam>
        /// <returns>экземпляр конкретной фабрики для производства деталей для соответствующего типа автомобилей</returns>
        public static AbstractCarFactory GetFactory<T>() where T : AbstractCarFactory, new() {
            T factory = new();
            return factory;
        }
    }
}