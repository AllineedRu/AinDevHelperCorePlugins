namespace AinDevHelperMediatorPattern {
    /// <summary>
    /// Абстрактный класс "Посредника" (Mediator) - "Система управления авиарейсами"
    /// </summary>
    public abstract class FlightManagementSystem {
        /// <summary>
        /// Зарегистрировать участника
        /// </summary>
        /// <param name="participant">ссылка на экземпляр участника</param>
        public abstract void RegisterParticipant(Participant participant);

        /// <summary>
        /// Отправить сообщение участнику
        /// </summary>
        /// <param name="from">от кого отправлено сообщение</param>
        /// <param name="message">текст сообщения</param>
        public abstract void SendMessage(string from, string message);
    }
}