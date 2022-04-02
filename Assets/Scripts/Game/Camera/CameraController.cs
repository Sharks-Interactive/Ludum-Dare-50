using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chrio.Controls
{
    public class CameraController : SharksBehaviour
    {
        private Camera _camera;

        void Start()
        {
            _camera = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.mouseScrollDelta.y == 1)
                _camera.orthographicSize++;
            else if (Input.mouseScrollDelta.y == -1)
                _camera.orthographicSize--;
        }
    }
}
