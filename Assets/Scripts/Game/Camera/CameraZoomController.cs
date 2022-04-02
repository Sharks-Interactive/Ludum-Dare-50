using SharkUtils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Chrio.Controls
{
    public class CameraZoomController : SharksBehaviour
    {
        private Camera _camera;
        public float Sensitivity;
        public float DirSensitivity;
        private Vector2 _lastFrameMousePos = Vector2.zero;

        private Vector3 _mousePosDelta = Vector2.zero;

        [Tooltip("MinSize, MaxSize")]
        public Vector2 SizeConstraints = new Vector2(5, 70);

        private enum Dir
        {
            Up = 1,
            Down = -1,
        }    

        void Start() { _camera = GetComponent<Camera>(); _lastFrameMousePos = Mouse.current.position.ReadValue(); }

        void Update()
        {
            _mousePosDelta = Mouse.current.position.ReadValue() - _lastFrameMousePos;
            _lastFrameMousePos = Mouse.current.position.ReadValue();

            if (Mouse.current.middleButton.isPressed || Mouse.current.rightButton.isPressed || (Mouse.current.leftButton.isPressed && (Keyboard.current.leftCtrlKey.isPressed || Keyboard.current.rightCtrlKey.isPressed)))
                _camera.transform.position += _mousePosDelta / (-62.5f + _camera.orthographicSize); // Fuck what does this magic number mean
            if (Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed)
                _camera.transform.position = _camera.transform.position.UpdateAxisEuler(_camera.transform.position.x + ExtraFunctions.GetAxis("Horizontal") * Time.deltaTime * 10, ExtraFunctions.Axis.X);
            if (Keyboard.current.wKey.isPressed || Keyboard.current.sKey.isPressed)
                _camera.transform.position = _camera.transform.position.UpdateAxisEuler(_camera.transform.position.y + ExtraFunctions.GetAxis("Vertical") * Time.deltaTime * 10, ExtraFunctions.Axis.Y);

            if ((Mouse.current.scroll.ReadValue().y < 0 || Keyboard.current.qKey.wasPressedThisFrame) && _camera.orthographicSize < SizeConstraints.y)
            {
                MoveCamera(Dir.Up);
                _camera.orthographicSize += Sensitivity;
            }
            else if ((Mouse.current.scroll.ReadValue().y > 0 || Keyboard.current.eKey.wasPressedThisFrame) && _camera.orthographicSize > SizeConstraints.x)
            {
                MoveCamera(Dir.Down);
                _camera.orthographicSize -= Sensitivity;
            }
        }

        private void MoveCamera(Dir _direcction)
        {
            float _normalizedMousePos = Mouse.current.position.ReadValue().y / Screen.height;
            if (_normalizedMousePos < 0.7 && _normalizedMousePos > 0.3) return; // Middle of screen

            float _mousePos = (_normalizedMousePos < 0.5 ? (float)Dir.Up : (float)Dir.Down);
            _camera.transform.position += new Vector3(0, _mousePos * DirSensitivity * (float)_direcction, 0);
        }
    }
}
