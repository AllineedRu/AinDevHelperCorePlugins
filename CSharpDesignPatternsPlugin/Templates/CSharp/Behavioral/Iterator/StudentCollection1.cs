using System.Collections;
using System.Collections.Generic;

namespace AinDevHelperIteratorPattern {
    /// <summary>
    /// Класс "Коллекция студентов". Хранит список струдентов и внутренний класс итератора
    /// для обеспечения функциональности перебора элементов коллекции
    /// </summary>
    public class StudentCollection : IEnumerable {
        /// <summary>
        /// Список студентов
        /// </summary>
        private readonly List<Student> _students = new List<Student>();

        /// <summary>
        /// Добавить студента в коллекцию
        /// </summary>
        /// <param name="student">экземпляр студента для добавления в коллекцию</param>
        public void AddStudent(Student student) {
            _students.Add(student);
        }

        public IEnumerator GetEnumerator() {
            return new StudentIterator(this);
        }

        /// <summary>
        /// Класс итератора
        /// </summary>
        private sealed class StudentIterator : IEnumerator {
            private readonly StudentCollection _collection;
            private int _index = -1;

            public StudentIterator(StudentCollection collection) {
                _collection = collection;
            }

            public object Current {
                get { return _collection._students[_index]; }
            }

            public bool MoveNext() {
                _index++;
                return _index < _collection._students.Count;
            }

            public void Reset() {
                _index = -1;
            }
        }
    }
}