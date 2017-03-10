using System.Collections.Generic;
using UnityEngine;

namespace Core.Utility.Dir {

    public class DirectionDependency {

        /// <summary>
        /// Main direction
        /// </summary>
        public Direction mainDirection { get; private set; }

        /// <summary>
        /// World vectors of directions relative to mainDirection.
        /// </summary>
        public IDictionary<Direction, Vector2> dirs { get; private set; }

        /// <summary>
        /// Constructor. Sets mainDirection and creates instance of dirs dictionary.
        /// </summary>
        public DirectionDependency(Direction mainDirection) {
            this.mainDirection = mainDirection;
            dirs = new Dictionary<Direction, Vector2>();
        }

        /// <summary>
        /// Adds dependency to dirs dictionary.
        /// </summary>
        public void AddDependency(Direction dir, Vector2 dirVector) {
            if (!dirs.ContainsKey(dir))
                dirs.Add(dir, dirVector);
        }

        /// <summary>
        /// Get vector of direction dependent on mainDirection.
        /// </summary>
        public Vector2? GetDirVector(Direction dir) {
            return dirs[dir];
        }
    }
}