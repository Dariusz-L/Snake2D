using Core.Common;

namespace Core {

    public interface IMainController : IController {

        /// <summary>
        /// Adds subcontroller to MainController.
        /// </summary>
        void AddController(IController controller);

        /// <summary>
        /// Returns controller of given type if exists.
        /// </summary>
        T GetController<T>() where T : IController;
    }

}
