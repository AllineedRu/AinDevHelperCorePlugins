namespace AinDevHelperCommandPattern {
    /// <summary>
    /// Конкретная команда для движения робота вперед
    /// </summary>
    public class MoveForwardCommand : ICommand {
        private Robot robot;

        public MoveForwardCommand(Robot robot) {
            this.robot = robot;
        }

        public void Execute() {
            robot.MoveForward();
        }
    }
}