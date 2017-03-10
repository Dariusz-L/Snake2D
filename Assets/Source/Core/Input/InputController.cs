using Core.Event;
using Core.Scripts;

namespace Core.Input {

    public abstract class InputController : IInputController {

        /// <summary>
        /// Reference to event controller.
        /// </summary>
        protected IEventController eventController { get; private set; }

        /// <summary>
        /// Sets reference to event controller.
        /// </summary>
        public void OnStart() {
            eventController = UnityScene.GetController<EventController>();
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        public abstract void Update();
    }

}
