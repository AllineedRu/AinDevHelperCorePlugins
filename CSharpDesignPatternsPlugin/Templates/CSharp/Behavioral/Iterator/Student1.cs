namespace AinDevHelperIteratorPattern {
    /// <summary>
    /// Класс студента
    /// </summary>
    public class Student {
        /// <summary>
        /// Имя студента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возраст студента
        /// </summary>
        public int Age { get; set; }

        public Student(string name, int age) {
            Name = name;
            Age = age;
        }
    }
}