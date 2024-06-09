using System.Diagnostics.CodeAnalysis;

namespace AinDevHelperMethodCascadingTechniqueExample {
    /// <summary>
    /// Класс, описывающий сотрудника
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public short Age { get; set; }

        /// <summary>
        /// Полное имя сотрудника
        /// </summary>
        public string FullName { get; set; } = "";

        /// <summary>
        /// Занимаемая сотрудником должность
        /// </summary>
        public string Position { get; set; } = "";

        /// <summary>
        /// Департамент, в котором работает сотрудник
        /// </summary>
        public string Department { get; set; } = "";

        /// <summary>
        /// Приведение текущего экземпляра класса к строке
        /// </summary>
        /// <returns>строкове представление сотрудника и значений его внутренних свойств</returns>
        public override string? ToString() {
            return $"Employee@{GetHashCode()} {{FullName={FullName}, Age={Age}, Position={Position}, Department={Department}}}";
        }

        /// <summary>
        /// Конструктор класса без параметров
        /// </summary>
        public Employee() {
        }

        /// <summary>
        /// Конструктор с параметрами. Инициализирует экземпляр сотрудника с заполненным полным именем
        /// </summary>
        /// <param name="fullName">полное имя сотрудника</param>
        public Employee(string fullName) {
            FullName = fullName;
        }

        /// <summary>
        /// Конструктор с параметрами. Инициализирует экземпляр сотрудника с заполненным полным именем 
        /// и с указанием возраста сотрудника
        /// </summary>
        /// <param name="fullName">полное имя сотрудника</param>
        /// <param name="age">возраст сотрудника</param>
        public Employee(string fullName, short age) {
            FullName = fullName;
            Age = age;
        }

        /// <summary>
        /// Модифицировать текущий экземпляр сотрудника, присвоив ему новое значение
        /// полного имени и вернуть ссылку на текущий экземпляр сотрудника
        /// </summary>
        /// <param name="fullName">новое полное имя сотрудника</param>
        /// <returns>ссылка на текущий экземпляр сотрудника</returns>
        public Employee WithFullName([DisallowNull] string fullName) {
            FullName = fullName;
            return this;
        }

        /// <summary>
        /// Модифицировать текущий экземпляр сотрудника, присвоив ему новое значение
        /// возраста и вернуть ссылку на текущий экземпляр сотрудника
        /// </summary>
        /// <param name="age">новый возраст сотрудника</param>
        /// <returns>ссылка на текущий экземпляр сотрудника</returns>
        public Employee WithAge([DisallowNull] short age) {
            Age = age;
            return this;
        }

        /// <summary>
        /// Модифицировать текущий экземпляр сотрудника, присвоив ему новое значение
        /// занимаемой должности и вернуть ссылку на текущий экземпляр сотрудника
        /// </summary>
        /// <param name="position">новая занимаемая должность сотрудника</param>
        /// <returns>ссылка на текущий экземпляр сотрудника</returns>
        public Employee WithPosition([DisallowNull] string position) {
            Position = position;
            return this;
        }

        /// <summary>
        /// Модифицировать текущий экземпляр сотрудника, присвоив ему новое значение
        /// занимаемой должности и вернуть ссылку на текущий экземпляр сотрудника
        /// </summary>
        /// <param name="department">новый департамент, в который будет распределён сотрудник</param>
        /// <returns>ссылка на текущий экземпляр сотрудника</returns>
        public Employee WithDepartment([DisallowNull] string department) {
            Department = department;
            return this;
        }
    }
}