namespace AinDevHelperObserverPattern {
    /// <summary>
    /// Интерфейс для подписчика
    /// </summary>
    public interface ISubscriber {
        void Update(string post);
    }
}