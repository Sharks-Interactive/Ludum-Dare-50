using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace Chrio.Interaction
{
    /// <summary>
    /// Purpose: Interface for interactable elements
    /// </summary>
    public interface IBaseInteractable
    {
        public string InteractionText { get; set; }

        public Key InteractionKey { get; }

        public GamepadButton InteractionButton { get; }

        void OnInteracted();

        void WhileInteract();

        void OnInteractEnd();
    }
}
