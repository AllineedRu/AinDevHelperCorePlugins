namespace AinDevHelperCommandPattern {
    /// <summary>
    /// Конкретная команда для движения робота назад
    /// </summary>
    public class MoveBackwardCommand : ICommand {
        private Robot robot;

        public MoveBackwardCommand(Robot robot) {
            this.robot = robot;
        }

        public void Execute() {
            robot.MoveBackward();
        }
    }
}