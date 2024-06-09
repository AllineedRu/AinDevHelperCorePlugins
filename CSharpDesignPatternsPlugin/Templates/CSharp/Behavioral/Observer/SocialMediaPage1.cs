﻿using System;
using System.Collections.Generic;

namespace AinDevHelperObserverPattern {
    /// <summary>
    /// Класс страницы в социальной сети
    /// </summary>
    public class SocialMediaPage {
        /// <summary>
        /// Список подписчиков на события страницы
        /// </summary>
        private List<ISubscriber> subscribers = new List<ISubscriber>();

        /// <summary>
        /// Добавить нового подписчика
        /// </summary>
        public void AddSubscriber(ISubscriber subscriber) {
            subscribers.Add(subscriber);
        }

        /// <summary>
        /// Удалить подписчика
        /// </summary>
        public void RemoveSubscriber(ISubscriber subscriber) {
            subscribers.Remove(subscriber);
        }

        /// <summary>
        /// Добавить новый пост на страницу
        /// </summary>
        public void PostNewContent(string post) {
            Console.WriteLine($"Новый пост: {post}");
            NotifySubscribers(post);
        }

        /// <summary>
        /// Уведомить всех имеющихся подписчиков о новом посте на странице
        /// </summary>
        private void NotifySubscribers(string post) {
            foreach (var subscriber in subscribers) {
                subscriber.Update(post);
            }
        }
    }
}
