using DG.Tweening;
using UnityEngine.InputSystem;

namespace Chrio.Controls
{
    /// <summary>
    /// The current control type
    /// </summary>
    public enum ControlType
    {
        Keyboard,
        Gamepad
    }

    /// <summary>
    /// Purpose: Determines which input the user is using, and includes utility functions for controls
    /// </summary>
    public class Controls : SharksBehaviour
    {
        /// <summary>
        /// Determine which input method the player is using - switches by determing the last input device used
        /// </summary>
        public void Update()
        {
            if (Keyboard.current.anyKey.isPressed)
                GlobalState.Controls.CType = ControlType.Keyboard;

            foreach (InputControl input in Mouse.current.allControls)
                if (input.IsPressed()) GlobalState.Controls.CType = ControlType.Keyboard;

            if (Gamepad.current == null) return;
            foreach (InputControl input in Gamepad.current.allControls)
                if (input.IsPressed()) GlobalState.Controls.CType = ControlType.Gamepad;
        }

        /// <summary>
        /// Handle's running a fading controller rumble
        /// </summary>
        /// <param name="Intensity"> Intensity of the rumble </param>
        /// <param name="Duration"> Duration of the rumble/fade </param>
        public static void ControllerRumble(float Intensity = 1.0f, float Duration = 1.0f)
        {
            if (Gamepad.current != null)
            {
                Gamepad.current.SetMotorSpeeds(0.0f, Intensity); // Start rumble

                float speed = Intensity;
                DOTween.To(() => speed, v => { speed = v; Gamepad.current.SetMotorSpeeds(0.0f, speed); }, 0.0f, Duration); // Gradually fade out rumble
            }
        }
    }
}
