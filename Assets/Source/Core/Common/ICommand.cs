namespace Core.Common {

    public interface ICommand {

        /// <summary>
        /// Executes command.
        /// </summary>
        void Execute(params object[] args);

    }
}
