namespace Core.Common {

    public interface IController {

        /// <summary>
        /// Called once after construction.
        /// </summary>
        void OnStart();

        /// <summary>
        /// Called every frame.
        /// </summary>
        void Update();

    }

}
