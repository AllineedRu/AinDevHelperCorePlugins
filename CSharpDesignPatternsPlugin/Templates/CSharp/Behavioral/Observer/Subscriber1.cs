using System;

namespace AinDevHelperObserverPattern {
    /// <summary>
    /// Класс подписчика
    /// </summary>
    public class Subscriber : ISubscriber {
        private string name;

        public Subscriber(string name) {
            this.name = name;
        }

        public void Update(string post) {
            Console.WriteLine($"{name} получил уведомление: {post}");
        }
    }
}