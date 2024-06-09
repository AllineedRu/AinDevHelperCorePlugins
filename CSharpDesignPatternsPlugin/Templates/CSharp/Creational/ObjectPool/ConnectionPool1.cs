using System;
using System.Collections.Generic;

namespace AinDevHelperObjectPoolPattern {
    /// <summary>
    /// Пул объектов DatabaseConnection
    /// </summary>
    public class ConnectionPool {
        private readonly List<DatabaseConnection> connections = new List<DatabaseConnection>();
        private readonly int maxSize;

        public ConnectionPool(int size) {
            maxSize = size;
            for (int i = 0; i < size; i++) {
                connections.Add(new DatabaseConnection());
            }
        }

        public DatabaseConnection GetConnection() {
            if (connections.Count > 0) {
                DatabaseConnection connection = connections[0];
                connections.RemoveAt(0);
                return connection;
            } else {
                Console.WriteLine("Пул соединений пуст. Создано новое соединение.");
                return new DatabaseConnection();
            }
        }

        public void ReleaseConnection(DatabaseConnection connection) {
            if (connections.Count < maxSize) {
                connections.Add(connection);
            } else {
                connection.Disconnect();
            }
        }
    }
}