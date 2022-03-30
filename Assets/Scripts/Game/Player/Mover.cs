using SharkUtils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Chrio.Player 
{
    /// <summary>
    /// Purpose: Calculates movement from player input
    /// </summary>
    public class Mover
    {
        private PlayerStats _stats;

        public Vector2 GetMovement() => new Vector2(GetXMovement(), GetYMovement());

        public Mover(PlayerStats stats) => _stats = stats;

        private float GetYMovement()
        {
            float _movement = Keyboard.current.sKey.isPressed ? -1 : 0;
            _movement += Keyboard.current.wKey.isPressed ? 1 : 0;

            if (Gamepad.current != null)
            {
                _movement += Gamepad.current.leftStick.up.ReadValue();
                _movement -= Gamepad.current.leftStick.down.ReadValue();
            }

            return ExtraFunctions.Clamp(_movement, _stats.MaxSpeed);
        }

        private float GetXMovement()
        {
            float _movement = Keyboard.current.aKey.isPressed ? -1 : 0;
            _movement += Keyboard.current.dKey.isPressed ? 1 : 0;

            if (Gamepad.current != null)
            {
                _movement -= Gamepad.current.leftStick.left.ReadValue();
                _movement += Gamepad.current.leftStick.right.ReadValue();
            }

            return ExtraFunctions.Clamp(_movement, _stats.MaxSpeed);
        }
    }
}
