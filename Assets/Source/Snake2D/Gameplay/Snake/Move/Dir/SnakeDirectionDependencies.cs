using Core.Utility.Dir;
using System.Collections.Generic;
using UnityEngine;

namespace Snake2D.Gameplay.Snake.Move.Dir {

    public class SnakeDirectionDependencies {

        /// <summary>
        /// Dictionary of direction dependencies relative to mainDirection.
        /// </summary>
        public IDictionary<Direction, DirectionDependency> dirs { get; private set; }

        /// <summary>
        /// Constructor. Cretaes instance of dirs dictionary and adds dependencies.
        /// </summary>
        public SnakeDirectionDependencies() {
            dirs = new Dictionary<Direction, DirectionDependency>();

            AddDependency(Direction.UP, new Vector2(0, 1), new Vector2(-1, 0), new Vector2(1, 0));
            AddDependency(Direction.DOWN, new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0));
            AddDependency(Direction.LEFT, new Vector2(-1, 0), new Vector2(0, -1), new Vector2(0, 1));
            AddDependency(Direction.RIGHT, new Vector2(1, 0), new Vector2(0, 1), new Vector2(0, -1));
        }

        /// <summary>
        /// Adds dependency to dictionary
        /// </summary>
        private void AddDependency(Direction mainDir, Vector2 forward, Vector2 left, Vector2 right) {
            var dep = new DirectionDependency(mainDir);
            dep.AddDependency(Direction.FORWARD, forward);
            dep.AddDependency(Direction.LEFT, left);
            dep.AddDependency(Direction.RIGHT, right);
            dirs.Add(mainDir, dep);
        }

        /// <summary>
        /// Rreturns world vector of direction.
        /// </summary>
        public static Direction GetWorldDirection(Vector2 dirVec) {
            if (dirVec == new Vector2(0, 1))
                return Direction.UP;
            if (dirVec == new Vector2(0, -1))
                return Direction.DOWN;
            if (dirVec == new Vector2(1, 0))
                return Direction.RIGHT;
            if (dirVec == new Vector2(-1, 0))
                return Direction.LEFT;

            return Direction.WRONG;
        }

    }
}
