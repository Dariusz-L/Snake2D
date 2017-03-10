using Core.Common;
using System.Collections.Generic;

namespace Core {

    public class MainController : IMainController {

        /// <summary>
        /// List of all subcontrollers of a logic.
        /// </summary>
        private List<IController> _controllers;

        /// <summary>
        /// Contructor. Create controllers list instance.
        /// </summary>
        public MainController() {
            _controllers = new List<IController>();
        }

        /// <summary>
        /// Called once after construction.
        /// </summary>
        void IController.OnStart() {
            foreach (IController c in _controllers)
                c.OnStart();
        }

        /// <summary>
        /// Updates every controller in controllers list.
        /// </summary>
        void IController.Update() {
            foreach (IController c in _controllers)
                c.Update();
        }

        /// <summary>
        /// Adds subcontroller to MainController.
        /// </summary>
        public void AddController(IController controller) {
            _controllers.Add(controller);
        }

        /// <summary>
        /// Returns controller of given type if exists.
        /// </summary>
        T IMainController.GetController<T>() {
            return (T) _controllers.Find(c => c.GetType() == typeof(T));
        }
    }
}
