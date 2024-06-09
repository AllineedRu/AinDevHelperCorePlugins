using System.Collections.Generic;

namespace AinDevHelperMediatorPattern {
    /// <summary>
    /// Конкретный класс "Посредника" (Mediator) - "Система управления воздушным движением"
    /// </summary>
    public class AirTrafficControl : FlightManagementSystem {
        /// <summary>
        /// Словарь с участниками, взаимодействующими в рамках системы управления воздушным движением
        /// </summary>
        private readonly Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();

        /// <summary>
        /// Зарегистрировать очередного участника в системе
        /// </summary>
        /// <param name="participant"></param>
        public override void RegisterParticipant(Participant participant) {
            // Если участник с таким именем ещё не зарегистрирован в системе (т.е. его нет в словаре _participants),
            // то зарегистрировать его в системе (добавить в словарь)
            if (!_participants.ContainsValue(participant)) {
                _participants[participant.Name] = participant;
            }

            // Новому участнику назначить ссылку на текущий экземпляр посредника, т.е. ссылку
            // на данный экземпляр класса AirTrafficControl
            participant.FlightManagementSystem = this;
        }

        /// <summary>
        /// Реализация абстрактного метода <see cref="FlightManagementSystem.SendMessage(string, string)"/> в классе посредника <see cref="FlightManagementSystem"/>.
        /// Отправить сообщение от одного участника системы другим.
        /// </summary>
        /// <param name="from">имя/название участника, от которого отправляется сообщение</param>
        /// <param name="message">текст сообщения для отправки другим участникам</param>
        public override void SendMessage(string from, string message) {
            // Перебрать всех зарегистрированных участников в системе
            foreach (var participant in _participants.Values) {
                // Если имя отправителя сообщения не равно текущему рассматриваемому участнику, то
                // принять отправленное сообщение текущим рассматриваемым участником
                if (participant.Name != from) {
                    participant.ReceiveMessage(message);
                }
            }
        }
    }
}