using Chrio.Entities;
using Chrio.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Chrio.Interaction;

namespace Chrio.Player
{
    public class ClientInteraction : SharksBehaviour
    {
        private Collider2D _prevInteracted;
        private IBaseInteractable _prevInteractable;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!GlobalState.Game.Entities.WorldEntities.ContainsKey(collision.gameObject)) return;
            if (!collision.CompareTag("Entity/Interactable")) return;
            IBaseEntity interactedEntity;
            if (!GlobalState.Game.Entities.WorldEntities.TryGetValue(collision.gameObject, out interactedEntity)) return;
            IBaseInteractable interactable = interactedEntity as IBaseInteractable;
            if (interactable == null) return;
            InteractionUIManager.instance.SetInteractionText(interactable.InteractionText);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_prevInteracted == null || (_prevInteracted == null ? false : _prevInteracted.tag != collision.tag))
            {
                _prevInteracted = collision;
                if (!GlobalState.Game.Entities.WorldEntities.ContainsKey(collision.gameObject)) return;
                if (!collision.CompareTag("Entity/Interactable")) return;
                IBaseEntity interactedEntity;
                if (!GlobalState.Game.Entities.WorldEntities.TryGetValue(collision.gameObject, out interactedEntity)) return;
                IBaseInteractable interactable = interactedEntity as IBaseInteractable;
                if (interactable == null) return;
                _prevInteractable = interactable;
            }

            if (_prevInteractable == null) return;
            if (Keyboard.current.allKeys[(int)_prevInteractable.InteractionKey].wasPressedThisFrame)
            { _prevInteractable.OnInteracted(); return; }
            if (Keyboard.current.eKey.isPressed ||
                Gamepad.current != null ? Gamepad.current.buttonSouth.IsPressed() : false)
            {
                _prevInteractable.WhileInteract();
                InteractionUIManager.instance.Animator.SetBool("Visible", false);
            }
            else _prevInteractable.OnInteractEnd();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            InteractionUIManager.instance.Animator.SetBool("Visible", false);
            if (!GlobalState.Game.Entities.WorldEntities.ContainsKey(collision.gameObject)) return;
            if (!collision.CompareTag("Entity/Interactable")) return;
            IBaseEntity interactedEntity;
            if (!GlobalState.Game.Entities.WorldEntities.TryGetValue(collision.gameObject, out interactedEntity)) return;
            IBaseInteractable interactable = interactedEntity as IBaseInteractable;
            if (interactable == null) return;
            interactable.OnInteractEnd();
        }
    }
}
