using System;
using Core.Event;
using System.Diagnostics;
using UnityEngine;
using Snake2D.Gameplay.Snake.Move.Dir;
using Core.Utility.Dir;
using Snake2D.Gameplay.Snake.Body;
using Snake2D.Gameplay.Resource;
using Core.Scripts;
using Core.Common;
using Snake2D.Gameplay.Event;

namespace Snake2D.Gameplay.Snake.Move {

    public class SnakeMoveController : IController, IEventParticipant {

        /// <summary>
        /// Reference to event controller.
        /// </summary>
        private IEventController _eventController;

        /// <summary>
        /// Directions in which snake should go relative to snake's current move direction.
        /// </summary>
        private SnakeDirectionDependencies _dirDependencies;

        /// <summary>
        /// Current direction of snake move.
        /// </summary>
        public Direction _curWorldMoveDir;

        /// <summary>
        /// Command to turn. If null then don't turn.
        /// </summary>
        private SnakeTurnCommand _turnCommand = null;

        /// <summary>
        /// Counts when snake should move.
        /// </summary>
        private Stopwatch _nextMoveTimer;

        /// <summary>
        /// Reference to snake parts.
        /// </summary>
        private SnakeParts _snakeParts;

        /// <summary>
        /// Reference to Snake2DResourceData.
        /// </summary>
        private Snake2DResourceData _resourceData;

        /// <summary>
        /// Flag if snake has just eaten. If true move only head, without tail parts.
        /// </summary>
        private bool _feedEaten;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SnakeMoveController(SnakeParts snakeParts) {
            _nextMoveTimer = new Stopwatch();
            _dirDependencies = new SnakeDirectionDependencies();
            _snakeParts = snakeParts;
            _curWorldMoveDir = Direction.UP;
        }

        /// <summary>
        /// Starts move counter and gets reference to resourceData.
        /// </summary>
        public void OnStart() {
            _nextMoveTimer.Start();
            _resourceData = UnityScene.GetResourceManager().resourceData as Snake2DResourceData;
        }

        /// <summary>
        /// Checks if snake should move.
        /// </summary>
        public void Update() {
            if (_nextMoveTimer.ElapsedMilliseconds > _resourceData.snakeMoveDelaySeconds * 1000) {
                ProcessMovement();
                _nextMoveTimer.Reset();
                _nextMoveTimer.Start();
            }
        }

        /// <summary>
        /// Moves snake.
        /// </summary>
        private void ProcessMovement() {
            Move(CheckMoveDir());
            _eventController.Dispatch<SnakeMoveEvent>(new SnakeMoveEventArgs(_snakeParts));
        }

        /// <summary>
        /// Check in which direction snake should move.
        /// </summary>
        private Direction CheckMoveDir() {
            Direction newDir;

            if (_turnCommand != null) {
                newDir = _turnCommand.dir;
                _turnCommand = null;
            } else {
                newDir = Direction.FORWARD;
            }

            return newDir;
        }

        /// <summary>
        /// Responsible for snake move.
        /// </summary>
        private void Move(Direction newRelativeToSnakeDir) {
            Vector2 headLastPos = _snakeParts.head.transform.position;

            Vector2 moveDir = MoveHead(newRelativeToSnakeDir, _snakeParts.head.transform);
            _curWorldMoveDir = SnakeDirectionDependencies.GetWorldDirection(moveDir);

            if (_feedEaten) {
                _feedEaten = false;
                return;
            }

            MoveTailParts(headLastPos);
        }

        /// <summary>
        /// Moves only head.
        /// </summary>
        private Vector2 MoveHead(Direction newRelativeToSnakeDir, Transform headTransform) {
            Vector2 headPos = headTransform.position;
            DirectionDependency dep = _dirDependencies.dirs[_curWorldMoveDir];
            Vector2 moveDir = dep.dirs[newRelativeToSnakeDir];
            headPos += moveDir;
            headTransform.position = headPos;
            return moveDir;
        }

        /// <summary>
        /// Moves only tail parts of snake.
        /// </summary>
        private void MoveTailParts(Vector2 firstTilePos) {
            Vector2 lastTilePos = firstTilePos;
            foreach (var go in _snakeParts.tailParts) {
                Transform t = go.transform;
                Vector2 pos = t.position;
                pos = lastTilePos;
                lastTilePos = t.position;
                t.position = pos;
            }
        }

        /// <summary>
        /// Sets turn command. So in next movement snake will turn.
        /// </summary>
        private void OnTurnCommand(EventArgs args) {
            _turnCommand = (args as SnakeTurnCommandArgs).turnCommand;
        }

        /// <summary>
        /// Sets event controller reference and adds event listeners.
        /// </summary>
        public void Subscribe(IEventController eventController) {
            _eventController = eventController;
            eventController.AddListener<SnakeTurnCommandEvent>(OnTurnCommand);
            eventController.AddListener<FeedEatenEvent>(OnFeedEaten);
        }

        /// <summary>
        /// If snake has just eaten then set eaten flat to true.
        /// </summary>
        private void OnFeedEaten(EventArgs args) {
            _feedEaten = true;
        }
    }

}