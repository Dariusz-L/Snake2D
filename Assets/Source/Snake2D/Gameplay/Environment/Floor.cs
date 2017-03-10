using System.Collections.Generic;
using UnityEngine;

namespace Snake2D.Gameplay.Environment {

    public class Floor {

        /// <summary>
        /// Contains positions of all tiles in game floor.
        /// </summary>
        private IList<Vector2> _allFloorTilesPositions;

        /// <summary>
        /// Constructor. Inits _floorTilesPositions list.
        /// </summary>
        public Floor() {
            InitFloorTilesList();
        }

        /// <summary>
        /// Checks is position is in floor rect. 
        /// </summary>
        public bool IsOnTheFloor(Vector2 pos) {
            foreach (var p in _allFloorTilesPositions)
                if (pos == p)
                    return true;

            return false;
        }

        /// <summary>
        /// Fills list with positions of all tiles in game floor.
        /// </summary>
        private void InitFloorTilesList() {
            _allFloorTilesPositions = new List<Vector2>();

            foreach (var r in GameObject.Find("Floor").GetComponentsInChildren<SpriteRenderer>()) {
                _allFloorTilesPositions.Add(r.transform.position);
            }
        }

        /// <summary>
        /// Gets random tile position.
        /// </summary>
        public Vector2 GetRandomTilePosition() {
            return _allFloorTilesPositions[UnityEngine.Random.Range(0, _allFloorTilesPositions.Count)];
        }
    }
}