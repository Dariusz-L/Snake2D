using Core.Common;
using Core.Utility.Dir;

namespace Snake2D.Gameplay.Snake.Move {

    public class SnakeTurnCommand : ICommand {

        /// <summary>
        /// Constructor. Sets dir.
        /// </summary>
        public SnakeTurnCommand(Direction dir) {
            this.dir = dir;
        }

        /// <summary>
        /// Direction relative gameObject in which should turn.
        /// </summary>
        public Direction dir { get; private set; }

        /// <summary>
        /// Executes instruction.
        /// </summary>
        public void Execute(params object[] args) {}

    }
}