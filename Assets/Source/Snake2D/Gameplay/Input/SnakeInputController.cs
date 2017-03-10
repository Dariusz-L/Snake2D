using Core.Input;
using Core.Utility.Dir;
using Snake2D.Gameplay.Event;
using Snake2D.Gameplay.Snake.Move;
using UnityEngine;

namespace Snake2D.Gameplay.Input {

    public class SnakeInputController : InputController {

        /// <summary>
        /// If left side on screen pointer then turn left.
        /// If right side on screen pointer then turn right.
        /// </summary>
        public override void Update() {
            if((UnityEngine.Input.touchCount > 0 &&
                UnityEngine.Input.touches[0].phase == TouchPhase.Began) ||
                UnityEngine.Input.GetMouseButtonDown(0)) {

                Vector2 p = UnityEngine.Input.mousePosition;

                SnakeTurnCommand command;
                if (p.x < Screen.width * 0.5f)
                    command = new SnakeTurnCommand(Direction.LEFT);
                else
                    command = new SnakeTurnCommand(Direction.RIGHT);

                eventController.Dispatch<SnakeTurnCommandEvent>(new SnakeTurnCommandArgs(command));
            }
        }

    }

}
