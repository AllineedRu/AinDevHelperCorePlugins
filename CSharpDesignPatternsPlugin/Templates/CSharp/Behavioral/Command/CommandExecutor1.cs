namespace AinDevHelperCommandPattern {
    /// <summary>
    /// Класс, который будет выполнять команды
    /// </summary>
    public class CommandExecutor {
        private ICommand command;

        public void SetCommand(ICommand command) {
            this.command = command;
        }

        public void ExecuteCommand() {
            command.Execute();
        }
    }
}
