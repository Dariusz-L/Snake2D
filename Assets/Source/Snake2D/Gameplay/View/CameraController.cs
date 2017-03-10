using Core.Common;
using UnityEngine;

namespace Snake2D.Gameplay.View {

    public class CameraController : IController {

        /// <summary>
        /// Makes camera view field a bit larger.
        /// </summary>
        public const float VIEW_RANGE_OFFSET = 0.1f;

        /// <summary>
        /// Scale camera view.
        /// </summary>
        public void OnStart() {
            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            Bounds floorBounds = GameObject.Find("Floor").GetComponent<Collider2D>().bounds;

            Vector3 camPos = cam.transform.position;
            camPos.x = floorBounds.center.x;
            camPos.y = floorBounds.center.y;
            cam.transform.position = camPos;

            float extent = Screen.width <= Screen.height ? 
                floorBounds.extents.x * (Screen.height / (float) Screen.width) :
                floorBounds.extents.y;

            cam.orthographicSize = extent + VIEW_RANGE_OFFSET;
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        public void Update() {}
    }

}
