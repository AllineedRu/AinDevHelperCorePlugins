namespace AinDevHelperAbstractFactoryPattern {
    /// <summary>
    /// Абстрактный класс для изготовления различных типов двигателей для автомобилей
    /// </summary>
    public abstract class AbstractCarEngine {
        /// <summary>
        /// Абстрактный метод для печати на консоли деталей по двигателю автомобиля
        /// </summary>
        public abstract void PrintCarEngineDetails();
    }
}