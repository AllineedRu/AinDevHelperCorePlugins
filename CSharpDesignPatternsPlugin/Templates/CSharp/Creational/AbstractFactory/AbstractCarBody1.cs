namespace AinDevHelperAbstractFactoryPattern {
    /// <summary>
    /// Абстрактный класс для изготовления различных видов корпусов для автомобилей
    /// </summary>
    public abstract class AbstractCarBody {
        /// <summary>
        /// Абстрактный метод для печати на консоли деталей по корпусу автомобиля
        /// </summary>
        public abstract void PrintCarBodyDetails();
    }
}